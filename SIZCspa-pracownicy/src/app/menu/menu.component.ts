import { Component, OnInit } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';
import { PozycjeMenuService } from '../_serwisy/pozycjeMenu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  pozycjeMenu: PobierzPozycjaMenu[];

  constructor(private alertService: AlertService,
              private pozycjeMenuService: PozycjeMenuService) { }

  ngOnInit() {
    this.pobierzMenu();
  }

  pobierzMenu() {
    this.pozycjeMenuService.pobierzPozycjeMenuWszystkie().subscribe((pozycjeMenu: PobierzPozycjaMenu[]) => {
      this.pozycjeMenu = pozycjeMenu;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu menu');
    });
  }

}
