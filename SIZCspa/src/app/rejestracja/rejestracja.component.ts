import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-rejestracja',
  templateUrl: './rejestracja.component.html',
  styleUrls: ['./rejestracja.component.css']
})
export class RejestracjaComponent implements OnInit {
  @Output() anulujRejestracje = new EventEmitter();
  klient: any = {};

  constructor(private autoryzacjaService: AutoryzacjaService, private alertService: AlertService) { }

  ngOnInit() {
  }

  zarejestruj() {
    this.autoryzacjaService.zarejestruj(this.klient).subscribe(() => {
      this.alertService.success('Rejestracja przebiegła pomyślnie');
    }, error => {
      this.alertService.danger('Błąd przy rejestracji');
    });
  }

  anuluj() {
    this.anulujRejestracje.emit(false);
    this.alertService.info('Anulowano rejestrację');
  }

}
