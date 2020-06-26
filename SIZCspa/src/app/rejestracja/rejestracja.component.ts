import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-rejestracja',
  templateUrl: './rejestracja.component.html',
  styleUrls: ['./rejestracja.component.css']
})
export class RejestracjaComponent implements OnInit {
  klient: any = {};
  formularzRejestracji: FormGroup;

  constructor(private autoryzacjaService: AutoryzacjaService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
    this.formularzRejestracji = new FormGroup({
      imie: new FormControl('', Validators.required),
      nazwisko: new FormControl('', Validators.required),
      adresEmail: new FormControl('', [Validators.required, Validators.email]),
      nrTelStacjonarny: new FormControl(),
      nrTelKomorkowy: new FormControl(),
      kodPocztowy: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(5)]),
      miejscowosc: new FormControl('', Validators.required),
      ulica: new FormControl(),
      nrBudynek: new FormControl(),
      nrMieszkanie: new FormControl(),
      haslo: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),
      potwierdzHaslo: new FormControl('', Validators.required)
    }, this.czyHaslaJednakowe);
  }

  czyHaslaJednakowe(fg: FormGroup) {
    return fg.get('haslo').value === fg.get('potwierdzHaslo').value ? null : {'nieprawidlowePowtorzoneHaslo': true};
  }

  zarejestruj() {
    if (this.formularzRejestracji.valid) {
      this.autoryzacjaService.zarejestruj(this.formularzRejestracji.value).subscribe(() => {
        this.alertService.success('Rejestracja przebiegła pomyślnie');
        this.router.navigate(['/stronaGlowna']);
      }, error => {
        this.alertService.danger('Błąd przy rejestracji');
      });
    }
    else
    {
      this.alertService.warning('Błędnie wypełniony formularz rejestracji');
    }

  }

  anuluj() {
    this.alertService.info('Anulowano rejestrację');
    this.router.navigate(['/stronaGlowna']);
  }

}
