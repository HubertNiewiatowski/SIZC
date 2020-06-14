import { Component, OnInit, DoCheck, AfterContentInit } from '@angular/core';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';
import { PozycjeMenuService } from '../_serwisy/pozycjeMenu.service';
import { AlertService } from 'ngx-alerts';
import { Router, ActivatedRoute } from '@angular/router';
import { DlaPozycjaMenuSkladnik } from '../_models/dlaPozycjaMenuSkladnik';

@Component({
  selector: 'app-menu-edytuj',
  templateUrl: './menu-edytuj.component.html',
  styleUrls: ['./menu-edytuj.component.css']
})
export class MenuEdytujComponent implements OnInit {
  pozycjaMenu: PobierzPozycjaMenu = {} as PobierzPozycjaMenu;

  constructor(private alertService: AlertService, private pozycjeMenuService: PozycjeMenuService,
              private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.pobierzPozycjeMenu();
  }

  pobierzPozycjeMenu() {
    this.pozycjeMenuService.pobierzPozycjeMenuPoId(+this.route.snapshot.params.id).subscribe((pozycjaMenu: PobierzPozycjaMenu) => {
      this.pozycjaMenu = pozycjaMenu;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu pozycji');
    });
  }

  usunPozycje() {
    this.pozycjeMenuService.usunPozycjeMenu(+this.route.snapshot.params.id).subscribe(next => {
      this.alertService.success('Usunięto pozycję menu');
    }, error => {
      this.alertService.warning('Błąd w takcie usuwania pozycji');
    }, () => {
      this.router.navigate(['/menu']);
    });

  }

  anuluj() {
    this.alertService.info('Anulowano edycję pozycji');
    this.router.navigate(['/menu']);
  }

}
