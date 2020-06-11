import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rejestracja',
  templateUrl: './rejestracja.component.html',
  styleUrls: ['./rejestracja.component.css']
})
export class RejestracjaComponent implements OnInit {
  klient: any = {};

  constructor(private autoryzacjaService: AutoryzacjaService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
  }

  zarejestruj() {
    this.autoryzacjaService.zarejestruj(this.klient).subscribe(() => {
      this.alertService.success('Rejestracja przebiegła pomyślnie');
      this.router.navigate(['/zamowienia']);
    }, error => {
      this.alertService.danger('Błąd przy rejestracji');
    });
  }

  anuluj() {
    this.alertService.info('Anulowano rejestrację');
    this.router.navigate(['/stronaGlowna']);
  }

}
