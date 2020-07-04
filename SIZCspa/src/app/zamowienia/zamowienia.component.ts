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
  brakZamowien: boolean;

  constructor(private alertService: AlertService,
              private zamowieniaService: ZamowieniaService, private autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
    this.nameId = this.autoryzacja.decodedToken.nameid;
    this.pobierzZamowienia();
  }

  pobierzZamowienia() {
    this.zamowieniaService.pobierzZamowieniaKlienta(this.nameId).subscribe(
      zamowienia => {
      if (zamowienia.length > 0) {
        this.zamowienia = zamowienia;
      }
      else {
        this.brakZamowien = true;
        this.alertService.info('Twoje konto nie posiada złożonych zamówień');
      }
    }, error => {
        this.alertService.danger('Błąd przy pobieraniu zamowień');
    }
  );
}
  czyNiePosiadaZamowien() {
    return this.brakZamowien;
  }

}
