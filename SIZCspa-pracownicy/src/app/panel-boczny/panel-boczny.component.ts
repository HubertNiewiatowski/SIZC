import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-panel-boczny',
  templateUrl: './panel-boczny.component.html',
  styleUrls: ['./panel-boczny.component.css']
})
export class PanelBocznyComponent implements OnInit {

  opened = true;

  constructor() { }

  ngOnInit() {
  }

  toggleSidebar() {
    this.opened = !this.opened;
  }

}
