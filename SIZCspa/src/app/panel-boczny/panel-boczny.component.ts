import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Component({
  selector: 'app-panel-boczny',
  templateUrl: './panel-boczny.component.html',
  styleUrls: ['./panel-boczny.component.css']
})
export class PanelBocznyComponent implements OnInit {

  opened = true;

  constructor(public autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
  }

  zalogowany() {
    return this.autoryzacja.zalogowany();
  }

  toggleSidebar() {
    this.opened = !this.opened;
  }



}
