import { Component, OnInit, DoCheck } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { DodajZamowienie } from '../_models/dodajZamowienie';
import { ActivatedRoute, Router } from '@angular/router';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { PozycjeMenuService } from '../_serwisy/pozycjeMenu.service';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-menu-zamow',
  templateUrl: './menu-zamow.component.html',
  styleUrls: ['./menu-zamow.component.css']
})
export class MenuZamowComponent implements OnInit , DoCheck {
  pozycjaMenu: PobierzPozycjaMenu = {} as PobierzPozycjaMenu;
  zamowienie: DodajZamowienie = {} as DodajZamowienie;
  nameId: any;
  formularzZamowienia: FormGroup;


  constructor(private zamowieniaService: ZamowieniaService, private alertService: AlertService,
              private route: ActivatedRoute, private router: Router, private autoryzacja: AutoryzacjaService,
              private pozycjeMenuService: PozycjeMenuService) {  }

  ngOnInit() {
    this.pobierzPozycjeMenu();

    // console.log(this.pozycjaMenu.nazwaPozycja);

    this.nameId = this.autoryzacja.decodedToken.nameid;

    this.formularzZamowienia = new FormGroup({
      dataRealizacji: new FormControl('', Validators.required),
      kodPocztowy: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(5)]),
      miejscowosc: new FormControl('', Validators.required),
      ulica: new FormControl(),
      nrBudynek: new FormControl(),
      nrMieszkanie: new FormControl(),
    });


  }

  ngDoCheck()
  {
    console.log(this.pozycjaMenu.nazwaPozycja);

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

    this.zamowienie.platnoscTypID = 2;

    this.zamowienie.zamowienieStatusID = 1;

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
