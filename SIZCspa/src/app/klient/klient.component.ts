import { Component, OnInit } from '@angular/core';
import { PobierzKlient } from '../_models/pobierzKlient';
import { AlertService } from 'ngx-alerts';
import { HttpClient } from '@angular/common/http';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { KlienciService } from '../_serwisy/klienci.service';

@Component({
  selector: 'app-klient',
  templateUrl: './klient.component.html',
  styleUrls: ['./klient.component.css']
})
export class KlientComponent implements OnInit {
  klient: PobierzKlient;
  nameId: any;

  constructor(private http: HttpClient, private alertService: AlertService,
              private klientService: KlienciService, private autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
    this.nameId = this.autoryzacja.decodedToken.nameid;
    this.pobierzKlienta();
  }

  pobierzKlienta() {
    this.klientService.pobierzKlienta(this.nameId).subscribe((klient: PobierzKlient) => {
      this.klient = klient;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu danych klienta');
    });
  }

}
