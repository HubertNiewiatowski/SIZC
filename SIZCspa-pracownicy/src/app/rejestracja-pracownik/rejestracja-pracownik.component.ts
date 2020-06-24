import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-rejestracja-pracownik',
  templateUrl: './rejestracja-pracownik.component.html',
  styleUrls: ['./rejestracja-pracownik.component.css']
})
export class RejestracjaPracownikComponent implements OnInit {
  formularzRejestracji: FormGroup;

  constructor(private autoryzacjaService: AutoryzacjaService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
    this.formularzRejestracji = new FormGroup({
      login: new FormControl('', Validators.required),
      haslo: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),
      potwierdzHaslo: new FormControl('', Validators.required),
      idRoli: new FormControl('', Validators.required),
    }, this.czyHaslaJednakowe);
  }

  czyHaslaJednakowe(fg: FormGroup) {
    return fg.get('haslo').value === fg.get('potwierdzHaslo').value ? null : {'nieprawidłowe': true};
  }

  zarejestruj() {
    if (this.formularzRejestracji.valid) {
      this.autoryzacjaService.zarejestruj(this.formularzRejestracji.value).subscribe(() => {
        this.alertService.success('Rejestracja przebiegła pomyślnie');
        this.router.navigate(['/pracownicy']);
      }, error => {
        this.alertService.danger('Błąd przy rejestracji');
      });
      console.log(this.formularzRejestracji.value);
    }
    else
    {
      this.alertService.warning('Błędnie wypełniony formularz rejestracji');
    }
  }

  anuluj() {
    this.alertService.info('Anulowano rejestrację');
    this.router.navigate(['/pracownicy']);
  }

}
