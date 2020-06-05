import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Component({
  selector: 'app-panel-gorny',
  templateUrl: './panel-gorny.component.html',
  styleUrls: ['./panel-gorny.component.css']
})
export class PanelGornyComponent implements OnInit {
  klient: any = {};

  constructor(private autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
  }

  zaloguj() {
    this.autoryzacja.zaloguj(this.klient).subscribe(next => {
      console.log('Zalogowano pomyślnie');
    }, error => {
      console.log('Nie udało się zalogować');
    });
  }

  wyloguj() {
    localStorage.removeItem('token');
    console.log('Nastąpiło wylogowanie');
  }

  zalogowany() {
    const token = localStorage.getItem('token');
    return !!token;
  }
}
