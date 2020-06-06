import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-strona-glowna',
  templateUrl: './strona-glowna.component.html',
  styleUrls: ['./strona-glowna.component.css']
})
export class StronaGlownaComponent implements OnInit {
  trybRejestracji = false;

  constructor() { }

  ngOnInit() {
  }

  przelacznikRejestracja() {
    this.trybRejestracji = true;
  }

  wylaczTrybRejestracji(trybRejestracji: boolean) {
    this.trybRejestracji = trybRejestracji;
  }

}
