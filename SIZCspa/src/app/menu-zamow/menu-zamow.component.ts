import { Component, OnInit } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { DodajZamowienie } from '../_models/dodajZamowienie';
import { ActivatedRoute, Router } from '@angular/router';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';


@Component({
  selector: 'app-menu-zamow',
  templateUrl: './menu-zamow.component.html',
  styleUrls: ['./menu-zamow.component.css']
})
export class MenuZamowComponent implements OnInit {
  zamowienie: DodajZamowienie;
  nameId: any;


constructor(private zamowieniaService: ZamowieniaService, private alertService: AlertService,
            private route: ActivatedRoute, private router: Router, private autoryzacja: AutoryzacjaService) { }

ngOnInit() {

  this.nameId = this.autoryzacja.decodedToken.nameid;

  this.zamowienie = {
    koszt: 40,
    kodPocztowy: '12345',
    miejscowosc: 'miasto',
    ulica: 'ulica',
    nrBudynek: '1a',
    nrMieszkanie: '-',
    dataRealizacji: new Date(2020, 6, 21, 8, 41, 1),
    pozycjaMenuID: this.route.snapshot.params.id,
    klientID: this.nameId,
    platnoscTypID: 1,
  };

  this.zamowPozycje();
  }


  zamowPozycje() {
    this.zamowieniaService.dodajZamowienie(this.zamowienie).subscribe(next => {
      this.alertService.success('Zalogowano pomyślnie');
    }, error => {
      this.alertService.warning('Nie udało się zalogować');
    }, () => {
      this.router.navigate(['/zamowienia']);
    });
  }



}
