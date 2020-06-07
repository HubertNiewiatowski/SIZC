import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-panel-gorny',
  templateUrl: './panel-gorny.component.html',
  styleUrls: ['./panel-gorny.component.css']
})
export class PanelGornyComponent implements OnInit {

  constructor(public autoryzacja: AutoryzacjaService, private alertService: AlertService) { }

  ngOnInit() {
  }

  zalogowany() {
    return this.autoryzacja.zalogowany();
  }

  wyloguj() {
    localStorage.removeItem('token');
    this.alertService.info('Nastąpiło wylogowanie');
  }

}
