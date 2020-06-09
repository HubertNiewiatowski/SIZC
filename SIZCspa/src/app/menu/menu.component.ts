import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertService } from 'ngx-alerts';
import { PozycjaMenu } from '../_models/pozycjaMenu';
import { PozycjeMenuService } from '../_serwisy/pozycjeMenu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  pozycjeMenu: PozycjaMenu[];

  constructor(private http: HttpClient, private alertService: AlertService,
              private pozycjeMenuService: PozycjeMenuService) { }

  ngOnInit() {
    this.pobierzMenu();
  }

  pobierzMenu() {
    this.pozycjeMenuService.pobierzPozycjeMenu().subscribe((pozycjeMenu: PozycjaMenu[]) => {
      this.pozycjeMenu = pozycjeMenu;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu menu');
    });
  }
}
