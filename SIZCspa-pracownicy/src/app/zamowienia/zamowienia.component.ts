import { Component, OnInit } from '@angular/core';
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
  pracownikRolaId: any;

  constructor(private alertService: AlertService,
              private zamowieniaService: ZamowieniaService, private autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
    this.nameId = this.autoryzacja.decodedToken.nameid;
    this.pracownikRolaId = this.autoryzacja.decodedToken.PracownikRolaId;
    this.pobierzZamowienia();
  }

  pobierzZamowienia() {
    this.zamowieniaService.pobierzZamowieniaPracownika(this.nameId).subscribe((zamowienia: PobierzZamowienie[]) => {
      this.zamowienia = zamowienia;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu zamowień');
    });
  }

}
