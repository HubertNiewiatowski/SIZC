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
  klient: any = {};

  constructor(public autoryzacja: AutoryzacjaService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
  }

  zaloguj() {
    this.autoryzacja.zaloguj(this.klient).subscribe(next => {
      this.alertService.success('Logowanie przebiegło pomyślnie');
    }, error => {
      this.alertService.warning('Nieprawidłowy adres email lub hasło');
    }, () => {
      this.router.navigate(['/stronaGlowna']);
    });
  }
}
