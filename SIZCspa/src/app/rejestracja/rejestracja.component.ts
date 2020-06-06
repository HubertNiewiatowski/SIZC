import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Component({
  selector: 'app-rejestracja',
  templateUrl: './rejestracja.component.html',
  styleUrls: ['./rejestracja.component.css']
})
export class RejestracjaComponent implements OnInit {
  @Output() anulujRejestracje = new EventEmitter();
  klient: any = {};

  constructor(private autoryzacjaService: AutoryzacjaService) { }

  ngOnInit() {
  }

  zarejestruj() {
    this.autoryzacjaService.zarejestruj(this.klient).subscribe(() => {
      console.log('rejestracja przebiegła pomyślnie');
    }, error => {
      console.log(error);
    });
  }

  anuluj() {
    this.anulujRejestracje.emit(false);
    console.log('anulowano');
  }

}
