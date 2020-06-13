import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Component({
  selector: 'app-strona-glowna',
  templateUrl: './strona-glowna.component.html',
  styleUrls: ['./strona-glowna.component.css']
})
export class StronaGlownaComponent implements OnInit {
  klientImie: string;

  constructor(public autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
  }

  zalogowany() {
    if (this.autoryzacja.zalogowany())
    {
      this.klientImie = this.autoryzacja.decodedToken.unique_name;
      return true;
    }
    else
    {
      return false;
    }
  }

}
