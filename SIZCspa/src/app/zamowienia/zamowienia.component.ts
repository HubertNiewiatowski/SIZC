import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-zamowienia',
  templateUrl: './zamowienia.component.html',
  styleUrls: ['./zamowienia.component.css']
})
export class ZamowieniaComponent implements OnInit {

  zamowienia: any;


  constructor(private http: HttpClient, private alertService: AlertService) { }

  ngOnInit() {
    this.pobierzWartosci();
  }

  pobierzWartosci() {
    this.http.get('http://localhost:5000/api/zamowienia/klient/1').subscribe(odpowiedz =>
    {
      this.zamowienia = odpowiedz;
    }, blad =>
    {
      this.alertService.danger('Błąd przy pobieraniu menu');
    });
  }

}
