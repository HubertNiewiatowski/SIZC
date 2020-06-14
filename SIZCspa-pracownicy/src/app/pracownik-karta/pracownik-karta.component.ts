import { Component, OnInit, Input } from '@angular/core';
import { PobierzPracownik } from '../_models/pobierzPracownik';

@Component({
  selector: 'app-pracownik-karta',
  templateUrl: './pracownik-karta.component.html',
  styleUrls: ['./pracownik-karta.component.css']
})
export class PracownikKartaComponent implements OnInit {
  @Input() profilPracownika: PobierzPracownik;

  constructor() { }

  ngOnInit() {
  }

}
