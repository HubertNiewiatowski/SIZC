import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logowanie',
  templateUrl: './logowanie.component.html',
  styleUrls: ['./logowanie.component.css']
})

export class LogowanieComponent implements OnInit {

  // 1
  klient: any = {};

  // 2
  constructor(public autoryzacja: AutoryzacjaService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
  }

  zaloguj() {

    // 3
    this.autoryzacja.zaloguj(this.klient).subscribe(next => {

      // 4
      this.alertService.success('Logowanie przebiegło pomyślnie');

      // 5
    }, error => {
      this.alertService.warning('Nieprawidłowy adres email lub hasło');

      // 6
    }, () => {
      this.router.navigate(['/stronaGlowna']);
    });
  }

  anuluj() {

    // 7
    this.alertService.info('Anulowano logowanie');

    // 8
    this.router.navigate(['/stronaGlowna']);
  }
}
