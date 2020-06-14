import { Component, OnInit, DoCheck } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { DodajZamowienie } from '../_models/dodajZamowienie';
import { ActivatedRoute, Router } from '@angular/router';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { PozycjeMenuService } from '../_serwisy/pozycjeMenu.service';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';


@Component({
  selector: 'app-menu-zamow',
  templateUrl: './menu-zamow.component.html',
  styleUrls: ['./menu-zamow.component.css']
})
export class MenuZamowComponent implements OnInit , DoCheck {
  pozycjaMenu: PobierzPozycjaMenu = {} as PobierzPozycjaMenu;
  zamowienie: DodajZamowienie = {} as DodajZamowienie;
  nameId: any;


  constructor(private zamowieniaService: ZamowieniaService, private alertService: AlertService,
              private route: ActivatedRoute, private router: Router, private autoryzacja: AutoryzacjaService,
              private pozycjeMenuService: PozycjeMenuService) {  }

  ngOnInit() {
    this.pobierzPozycjeMenu();

    // console.log(this.pozycjaMenu.nazwaPozycja);

    this.nameId = this.autoryzacja.decodedToken.nameid;


  }

  ngDoCheck()
  {
    console.log(this.pozycjaMenu.nazwaPozycja);

    this.zamowienie.koszt = this.pozycjaMenu.cena + 5;

    this.zamowienie.pozycjaMenuID = this.route.snapshot.params.id;

    this.zamowienie.klientID = this.nameId;

    this.zamowienie.dataRealizacji = new Date(2020, 6, 21, 8, 41, 1);

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
    this.zamowieniaService.dodajZamowienieKlienta(this.zamowienie).subscribe(next => {
      this.alertService.success('Złożono zamówienie');
    }, error => {
      this.alertService.warning('Błąd w trakcie składania zamówienia');
    }, () => {
      this.router.navigate(['/zamowienia']);
    });
  }

  anuluj() {
    this.alertService.info('Anulowano składanie zamówienia');
    this.router.navigate(['/menu']);
  }

}
