import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';
import { Router } from '@angular/router';

@Component({
  selector: 'app-panel-gorny',
  templateUrl: './panel-gorny.component.html',
  styleUrls: ['./panel-gorny.component.css']
})
export class PanelGornyComponent implements OnInit {

  constructor(public autoryzacja: AutoryzacjaService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
  }

  zalogowany() {
    return this.autoryzacja.zalogowany();
  }

  wyloguj() {
    localStorage.removeItem('token');
    this.alertService.info('Nastąpiło wylogowanie');
    this.router.navigate(['/stronaGlowna']);
  }

}
