import { Component, OnInit } from '@angular/core';
import { PobierzKlient } from '../_models/pobierzKlient';
import { AlertService } from 'ngx-alerts';
import { HttpClient } from '@angular/common/http';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { KlienciService } from '../_serwisy/klienci.service';
import { AktualizujKlient } from '../_models/aktualizujKlient';
import { Router } from '@angular/router';

@Component({
  selector: 'app-klient',
  templateUrl: './klient.component.html',
  styleUrls: ['./klient.component.css']
})
export class KlientComponent implements OnInit {
  opened = false;
  klientDoPobrania: PobierzKlient;
  klientDoAktualizacji: AktualizujKlient = {} as AktualizujKlient;
  nameId: any;

  constructor(private http: HttpClient, private alertService: AlertService,
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
    this.klientService.aktualizujProfilKlienta(this.klientDoAktualizacji, this.nameId).subscribe(next => {
      this.alertService.success('Zalogowano pomyślnie');
    }, error => {
      this.alertService.warning('Błąd w trakcie aktualizowania profilu');
    }, () => {
      this.router.navigate(['/klient']);
    });
  }

  usunProfilKlienta() {
    this.klientService.usunProfilKlienta(this.nameId).subscribe(next => {
      this.alertService.success('Usunięto profil pomyślnie');
    }, error => {
      this.alertService.warning('Błąd w trakcie usuwania profilu');
    }, () => {
      this.wyloguj();
    });
  }

  toggleSidebar() {
    this.opened = !this.opened;
  }

  anuluj() {
    this.toggleSidebar();
    this.alertService.info('Anulowano edycję profilu');
    this.router.navigate(['/klient']);
  }

  wyloguj() {
    localStorage.removeItem('token');
    this.alertService.info('Nastąpiło wylogowanie');
    this.router.navigate(['/stronaGlowna']);
  }

}
