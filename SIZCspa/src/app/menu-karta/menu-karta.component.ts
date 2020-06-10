import { Component, OnInit, Input } from '@angular/core';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';
import { DlaPozycjaMenuSkladnik } from '../_models/dlaPozycjaMenuSkladnik';

@Component({
  selector: 'app-menu-karta',
  templateUrl: './menu-karta.component.html',
  styleUrls: ['./menu-karta.component.css']
})
export class MenuKartaComponent implements OnInit {
  @Input() pozycjaMenu: PobierzPozycjaMenu;
  @Input() skladniki: DlaPozycjaMenuSkladnik[];

  constructor() { }

  ngOnInit() {
  }

}
