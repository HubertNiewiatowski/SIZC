import { Component, OnInit, Input } from '@angular/core';
import { DlaZamowieniePozycjaMenu } from '../_models/dlaZamowieniePozycjaMenu';
import { DlaZamowieniePlatnoscTyp } from '../_models/dlaZamowieniePlatnoscTyp';
import { DlaZamowienieZamowienieStatus } from '../_models/dlaZamowienieZamowienieStatus';
import { Zamowienie } from '../_models/zamowienie';

@Component({
  selector: 'app-zamowienia-karta',
  templateUrl: './zamowienia-karta.component.html',
  styleUrls: ['./zamowienia-karta.component.css']
})
export class ZamowieniaKartaComponent implements OnInit {
  @Input() zamowienie: Zamowienie;
  @Input() pozycjaMenu: DlaZamowieniePozycjaMenu;
  @Input() platnoscTyp: DlaZamowieniePlatnoscTyp;
  @Input() zamowienieStatus: DlaZamowienieZamowienieStatus;


  constructor() { }

  ngOnInit() {
  }

}
