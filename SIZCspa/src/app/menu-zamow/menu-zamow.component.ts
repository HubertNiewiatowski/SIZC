import { Component, OnInit } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { DodajZamowienie } from '../_models/dodajZamowienie';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-menu-zamow',
  templateUrl: './menu-zamow.component.html',
  styleUrls: ['./menu-zamow.component.css']
})
export class MenuZamowComponent implements OnInit {
  zamowienie: DodajZamowienie;


constructor(private zamowieniaService: ZamowieniaService, private alertService: AlertService,
            private route: ActivatedRoute, private router: Router) { }

ngOnInit() {
  this.zamowienie = {
    koszt: 40,
    kodPocztowy: '12345',
    miejscowosc: 'miasto',
    ulica: 'ulica',
    nrBudynek: '1a',
    nrMieszkanie: '-',
    dataRealizacji: new Date(2020, 6, 21, 8, 41, 1),
    pozycjaMenuID: this.route.snapshot.params.id,
    klientID: 1,
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
      this.router.navigate(['/menu']);
    });
  }



}
