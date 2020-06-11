import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertService } from 'ngx-alerts';
import { PobierzZamowienie } from '../_models/pobierzZamowienie';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Component({
  selector: 'app-zamowienia',
  templateUrl: './zamowienia.component.html',
  styleUrls: ['./zamowienia.component.css']
})
export class ZamowieniaComponent implements OnInit {
  zamowienia: PobierzZamowienie[];
  nameId: any;

  constructor(private alertService: AlertService,
              private zamowieniaService: ZamowieniaService, private autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
    this.nameId = this.autoryzacja.decodedToken.nameid;
    this.pobierzZamowienia();
  }

  pobierzZamowienia() {
    this.zamowieniaService.pobierzZamowienia(this.nameId).subscribe((zamowienia: PobierzZamowienie[]) => {
      this.zamowienia = zamowienia;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu zamowień');
    });
  }

}
