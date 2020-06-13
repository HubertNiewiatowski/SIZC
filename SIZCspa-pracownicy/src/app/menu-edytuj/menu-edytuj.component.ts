import { Component, OnInit } from '@angular/core';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';
import { PozycjeMenuService } from '../_serwisy/pozycjeMenu.service';
import { AlertService } from 'ngx-alerts';
import { Router, ActivatedRoute } from '@angular/router';

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
  }

  pobierzPozycjeMenu() {
    this.pozycjeMenuService.pobierzPozycjeMenuPoId(+this.route.snapshot.params.id).subscribe((pozycjaMenu: PobierzPozycjaMenu) => {
      this.pozycjaMenu = pozycjaMenu;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu pozycji');
    });
  }

  edytujPozycje() {
    this.pozycjeMenuService.aktualizujPozycjeMenu(this.pozycjaMenu, this.pozycjaMenu.pozycjaMenuID).subscribe(next => {
      this.alertService.success('Zaktualizowano pozycję');
    }, error => {
      this.alertService.warning('Błąd w trakcie aktualizacji pozycji');
    }, () => {
      this.router.navigate(['/menu']);
    });

  }

  anuluj() {
    this.alertService.info('Anulowano edycję pozycji');
    this.router.navigate(['/menu']);
  }

}
