import { Component, OnInit } from '@angular/core';
import { PobierzKlient } from '../_models/pobierzKlient';
import { AlertService } from 'ngx-alerts';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { KlienciService } from '../_serwisy/klienci.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-klient',
  templateUrl: './klient.component.html',
  styleUrls: ['./klient.component.css']
})
export class KlientComponent implements OnInit {
  trybEdycjiDanych = false;
  klientDoPobrania: PobierzKlient = {} as PobierzKlient;
  nameId: any;

  constructor(private alertService: AlertService,
              private klientService: KlienciService, private autoryzacja: AutoryzacjaService,
              private router: Router) { }

  ngOnInit() {
    this.nameId = this.autoryzacja.decodedToken.nameid;
    this.pobierzProfilKlienta();
  }

  pobierzProfilKlienta() {
    this.klientService.pobierzProfilKlienta(this.nameId).subscribe((klient: PobierzKlient) => {
      this.klientDoPobrania = klient;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu danych klienta');
    });
  }

  aktualizujProfilKlienta() {
    this.klientService.aktualizujProfilKlienta(this.klientDoPobrania, this.nameId).subscribe(next => {
      this.alertService.success('Zaktualizowano profil');
    }, error => {
      this.alertService.warning('Błąd w trakcie aktualizowania profilu');
    }, () => {
      this.router.navigate(['/klient']);
    });
  }

  usunProfilKlienta() {
    this.klientService.usunProfilKlienta(this.nameId).subscribe(next => {
      this.alertService.success('Usunięto profil');
    }, error => {
      this.alertService.warning('Błąd w trakcie usuwania profilu');
    }, () => {
      this.wyloguj();
      this.router.navigate(['/klient']);
    });
  }

  przelacznikTrybuEdycji() {
    this.trybEdycjiDanych = !this.trybEdycjiDanych;
  }

  anuluj() {
    this.przelacznikTrybuEdycji();
    this.alertService.info('Anulowano edycję profilu');
    this.router.navigate(['/klient']);
  }

  wyloguj() {
    this.autoryzacja.wyloguj();
    this.alertService.info('Nastąpiło wylogowanie');
    this.router.navigate(['/stronaGlowna']);
  }

}
