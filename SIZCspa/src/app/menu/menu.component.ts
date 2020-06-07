import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  pozycjeMenu: any;

  constructor(private http: HttpClient, private alertService: AlertService) { }

  ngOnInit() {
    this.pobierzWartosci();
  }

  pobierzWartosci() {
    this.http.get('http://localhost:5000/api/pozycjemenu').subscribe(odpowiedz =>
    {
      this.pozycjeMenu = odpowiedz;
    }, blad =>
    {
      this.alertService.danger('Błąd przy pobieraniu menu');
    });
  }
}
