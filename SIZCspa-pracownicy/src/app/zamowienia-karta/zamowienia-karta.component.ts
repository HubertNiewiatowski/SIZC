import { Component, OnInit, Input } from '@angular/core';
import { DlaZamowieniePozycjaMenu } from '../_models/dlaZamowieniePozycjaMenu';
import { DlaZamowieniePlatnoscTyp } from '../_models/dlaZamowieniePlatnoscTyp';
import { DlaZamowienieZamowienieStatus } from '../_models/dlaZamowienieZamowienieStatus';
import { PobierzZamowienie } from '../_models/pobierzZamowienie';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Component({
  selector: 'app-zamowienia-karta',
  templateUrl: './zamowienia-karta.component.html',
  styleUrls: ['./zamowienia-karta.component.css']
})
export class ZamowieniaKartaComponent implements OnInit {
  @Input() zamowienie: PobierzZamowienie;
  @Input() pozycjaMenu: DlaZamowieniePozycjaMenu;
  @Input() platnoscTyp: DlaZamowieniePlatnoscTyp;
  @Input() zamowienieStatus: DlaZamowienieZamowienieStatus;

  pracownikRolaId: string;

  constructor(public autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
    this.pracownikRolaId = this.autoryzacja.decodedToken?.PracownikRolaId;
    this.rolaKucharz();
    this.rolaDostawca();
  }

  rolaKucharz() {
    if (this.pracownikRolaId === '1')
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  rolaDostawca() {
    if (this.pracownikRolaId === '2')
    {
      return true;
    }
    else
    {
      return false;
    }
  }

}
