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
  pracownikRolaId: string;
  brakZamowien: boolean;

  constructor(private alertService: AlertService,
              private zamowieniaService: ZamowieniaService, private autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
    this.brakZamowien = false;
    this.nameId = this.autoryzacja.decodedToken.nameid;
    this.pracownikRolaId = this.autoryzacja.decodedToken.PracownikRolaId;
    this.pobierzZamowienia();
  }

  pobierzZamowienia() {
    this.zamowieniaService.pobierzZamowieniaPracownika(this.nameId).subscribe(
      zamowienia => {
        if (zamowienia.length > 0) {
          this.zamowienia = zamowienia;
        }
        else {
          this.brakZamowien = true;
          this.alertService.info('Do Twojego konta nie przypisano żadnych zamówień');
        }
      }, error => {
          this.alertService.danger('Błąd przy pobieraniu zamowień');
      }
    );
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

  czyNiePosiadaZamowien() {
    return this.brakZamowien;
  }

}
