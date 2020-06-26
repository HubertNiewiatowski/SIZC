import { Component, OnInit } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { DodajZamowienie } from '../_models/dodajZamowienie';
import { ActivatedRoute, Router } from '@angular/router';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { PozycjeMenuService } from '../_serwisy/pozycjeMenu.service';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { plLocale } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { KlienciService } from '../_serwisy/klienci.service';
import { PobierzKlient } from '../_models/pobierzKlient';
import { DlaZamowieniePlatnoscTyp } from '../_models/dlaZamowieniePlatnoscTyp';


@Component({
  selector: 'app-menu-zamow',
  templateUrl: './menu-zamow.component.html',
  styleUrls: ['./menu-zamow.component.css']
})
export class MenuZamowComponent implements OnInit {
  pozycjaMenu: PobierzPozycjaMenu = {} as PobierzPozycjaMenu;
  zamowienie: DodajZamowienie = {} as DodajZamowienie;
  nameId: any;
  formularzZamowienia: FormGroup;
  typyPlatnosci: DlaZamowieniePlatnoscTyp[] = [];
  profilKlienta: PobierzKlient = {} as PobierzKlient;


  constructor(private zamowieniaService: ZamowieniaService, private alertService: AlertService,
              private route: ActivatedRoute, private router: Router, private autoryzacja: AutoryzacjaService,
              private pozycjeMenuService: PozycjeMenuService, private localeService: BsLocaleService,
              private klienciService: KlienciService) {  }

  ngOnInit() {
    this.pobierzPozycjeMenu();

    this.pobierzTypyPlatnosci();

    this.setDatepickerLanguage();


    // this.typyPlatnosci.push({platnoscTypID: 1, nazwaPlatnosc: 'gotówka'});
    // this.typyPlatnosci.push({platnoscTypID: 2, nazwaPlatnosc: 'blik'});
    // this.typyPlatnosci.push({platnoscTypID: 3, nazwaPlatnosc: 'przelew'});


    this.nameId = this.autoryzacja.decodedToken.nameid;

    this.formularzZamowienia = new FormGroup({
      kodPocztowy: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(5)]),
      miejscowosc: new FormControl('', Validators.required),
      ulica: new FormControl(),
      nrBudynek: new FormControl(),
      nrMieszkanie: new FormControl(),
      dataRealizacji: new FormControl('', Validators.required),
      platnoscTyp: new FormControl('', Validators.required)
    }, this.czyDataRealizacjiPrawidlowa);


    this.klienciService.pobierzProfilKlienta(this.nameId).subscribe((profilKlienta: PobierzKlient) => {
      this.profilKlienta = profilKlienta;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu profilu klienta');
    });
  }

  czyDataRealizacjiPrawidlowa(fg: FormGroup) {
    const aktualnaData = new Date();
    return fg.get('dataRealizacji').value > aktualnaData ? null : {'nieprawidłowaDataRealizacji': true};
  }

  setDatepickerLanguage() {
    defineLocale('pl', plLocale);
    this.localeService.use('pl');
  }

  pobierzPozycjeMenu() {
    this.pozycjeMenuService.pobierzPozycjeMenuPoId(+this.route.snapshot.params.id).subscribe((pozycjaMenu: PobierzPozycjaMenu) => {
      this.pozycjaMenu = pozycjaMenu;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu pozycji');
    });
  }

  pobierzTypyPlatnosci() {
    this.zamowieniaService.pobierzTypyPlatnosci().subscribe((typyPlatnosci: DlaZamowieniePlatnoscTyp[]) => {
      this.typyPlatnosci = typyPlatnosci;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu typów płatności');
    });
  }

  zamowPozycje() {
    if (this.formularzZamowienia.valid) {

      this.zamowienie.koszt = this.pozycjaMenu.cena + 5;

      this.zamowienie.kodPocztowy = this.formularzZamowienia.get('kodPocztowy').value;

      this.zamowienie.miejscowosc = this.formularzZamowienia.get('miejscowosc').value;

      this.zamowienie.ulica = this.formularzZamowienia.get('ulica').value;

      this.zamowienie.nrBudynek = this.formularzZamowienia.get('nrBudynek').value;

      this.zamowienie.nrMieszkanie = this.formularzZamowienia.get('nrMieszkanie').value;

      this.zamowienie.dataRealizacji = this.formularzZamowienia.get('dataRealizacji').value;

      this.zamowienie.pozycjaMenuID = this.route.snapshot.params.id;

      this.zamowienie.klientID = this.nameId;

      this.zamowienie.pracownikID = 1;

      this.zamowienie.platnoscTypID = this.formularzZamowienia.get('platnoscTyp').value;

      this.zamowienie.zamowienieStatusID = 1;

      this.zamowieniaService.dodajZamowienieKlienta(this.zamowienie).subscribe(next => {
        this.alertService.success('Złożono zamówienie');
      }, error => {
        this.alertService.warning('Błąd w trakcie składania zamówienia');
      }, () => {
        this.router.navigate(['/zamowienia']);
      });
    }
    else
    {
      this.alertService.warning('Błędnie wypełniony formularz składania zamówienia');
    }
  }

  anuluj() {
    this.alertService.info('Anulowano składanie zamówienia');
    this.router.navigate(['/menu']);
  }

  wypelnijFormularz() {
    this.formularzZamowienia.controls.kodPocztowy.patchValue(this.profilKlienta.kodPocztowy);
    this.formularzZamowienia.controls.miejscowosc.patchValue(this.profilKlienta.miejscowosc);
    this.formularzZamowienia.controls.ulica.patchValue(this.profilKlienta.ulica);
    this.formularzZamowienia.controls.nrBudynek.patchValue(this.profilKlienta.nrBudynek);
    this.formularzZamowienia.controls.nrMieszkanie.patchValue(this.profilKlienta.nrMieszkanie);
  }
}
