import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';
import { Router } from '@angular/router';
import { PanelBocznyComponent } from '../panel-boczny/panel-boczny.component';

@Component({
  selector: 'app-logowanie',
  templateUrl: './logowanie.component.html',
  styleUrls: ['./logowanie.component.css']
})
export class LogowanieComponent implements OnInit {
  pracownik: any = {};

  constructor(public autoryzacja: AutoryzacjaService, private panelBoczny: PanelBocznyComponent,
              private alertService: AlertService, private router: Router) { }

  ngOnInit() {
  }

  zaloguj() {
    this.autoryzacja.zaloguj(this.pracownik).subscribe(next => {
      this.alertService.success('Zalogowano pomyślnie');
    }, error => {
      this.alertService.warning('Nie udało się zalogować');
    }, () => {
      this.router.navigate(['/stronaGlowna']);
      this.panelBoczny.ngOnInit();
    });
  }

}
