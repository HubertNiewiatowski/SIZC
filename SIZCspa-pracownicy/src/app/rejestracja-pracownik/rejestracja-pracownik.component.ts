import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rejestracja-pracownik',
  templateUrl: './rejestracja-pracownik.component.html',
  styleUrls: ['./rejestracja-pracownik.component.css']
})
export class RejestracjaPracownikComponent implements OnInit {
  pracownik: any = {};

  constructor(private autoryzacjaService: AutoryzacjaService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
  }

  zarejestruj() {
    this.autoryzacjaService.zarejestruj(this.pracownik).subscribe(() => {
      this.alertService.success('Rejestracja przebiegła pomyślnie');
      this.router.navigate(['/stronaGlowna']);
    }, error => {
      this.alertService.danger('Błąd przy rejestracji');
    });
  }

  anuluj() {
    this.alertService.info('Anulowano rejestrację');
    this.router.navigate(['/stronaGlowna']);
  }

}
