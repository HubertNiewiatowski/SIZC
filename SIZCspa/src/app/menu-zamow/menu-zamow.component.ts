import { Component, OnInit, DoCheck } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { DodajZamowienie } from '../_models/dodajZamowienie';
import { ActivatedRoute, Router } from '@angular/router';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { PozycjeMenuService } from '../_serwisy/pozycjeMenu.service';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PlatnoscTyp } from '../_models/platnoscTyp';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { plLocale } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';


@Component({
  selector: 'app-menu-zamow',
  templateUrl: './menu-zamow.component.html',
  styleUrls: ['./menu-zamow.component.css']
})
export class MenuZamowComponent implements OnInit, DoCheck {
  pozycjaMenu: PobierzPozycjaMenu = {} as PobierzPozycjaMenu;
  zamowienie: DodajZamowienie = {} as DodajZamowienie;
  nameId: any;
  formularzZamowienia: FormGroup;
  typyPlatnosci: PlatnoscTyp[] = [];


  constructor(private zamowieniaService: ZamowieniaService, private alertService: AlertService,
              private route: ActivatedRoute, private router: Router, private autoryzacja: AutoryzacjaService,
              private pozycjeMenuService: PozycjeMenuService, private localeService: BsLocaleService) {  }

  ngOnInit() {
    this.pobierzPozycjeMenu();
    this.setDatepickerLanguage();


    this.typyPlatnosci.push({platnoscTypID: 1, nazwaPlatnosc: 'gotówka'});
    this.typyPlatnosci.push({platnoscTypID: 2, nazwaPlatnosc: 'blik'});
    this.typyPlatnosci.push({platnoscTypID: 3, nazwaPlatnosc: 'przelew'});


    this.nameId = this.autoryzacja.decodedToken.nameid;

    this.formularzZamowienia = new FormGroup({
      kodPocztowy: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(5)]),
      miejscowosc: new FormControl('', Validators.required),
      ulica: new FormControl(),
      nrBudynek: new FormControl(),
      nrMieszkanie: new FormControl(),
      dataRealizacji: new FormControl('', Validators.required),
      platnoscTyp: new FormControl('', Validators.required)
    });
  }


  ngDoCheck()
  {
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

  zamowPozycje() {
    if (this.formularzZamowienia.valid) {
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

}
