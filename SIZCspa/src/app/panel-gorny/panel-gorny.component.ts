import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-panel-gorny',
  templateUrl: './panel-gorny.component.html',
  styleUrls: ['./panel-gorny.component.css']
})
export class PanelGornyComponent implements OnInit {
  klient: any = {};

  constructor(public autoryzacja: AutoryzacjaService, private alertService: AlertService) { }

  ngOnInit() {
  }

  zaloguj() {
    this.autoryzacja.zaloguj(this.klient).subscribe(next => {
      this.alertService.success('Zalogowano pomyślnie');
    }, error => {
      this.alertService.warning('Nie udało się zalogować');
    });
  }

  wyloguj() {
    localStorage.removeItem('token');
    this.alertService.info('Nastąpiło wylogowanie');
  }

  zalogowany() {
    return this.autoryzacja.zalogowany();
  }
}
