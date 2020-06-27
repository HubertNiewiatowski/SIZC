import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AlertService } from 'ngx-alerts';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { KlienciService } from '../_serwisy/klienci.service';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { plLocale } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-raporty',
  templateUrl: './raporty.component.html',
  styleUrls: ['./raporty.component.css']
})
export class RaportyComponent implements OnInit {
  formularzZamowienia: FormGroup;
  formularzKlienci: FormGroup;

  iloscZamowien: number;
  iloscKlientow: number;



  constructor(private zamowieniaService: ZamowieniaService, private klienciService: KlienciService,
              private alertService: AlertService, private localeService: BsLocaleService, public datepipe: DatePipe) { }

  ngOnInit() {

    this.setDatepickerLanguage();

    this.formularzZamowienia = new FormGroup({
      dataPoczatkowaZamowienia: new FormControl('', Validators.required),
      dataKoncowaZamowienia: new FormControl('', Validators.required)
    });

    this.formularzKlienci = new FormGroup({
      dataPoczatkowaKlienci: new FormControl('', Validators.required),
      dataKoncowaKlienci: new FormControl('', Validators.required)
    });
  }


  setDatepickerLanguage() {
    defineLocale('pl', plLocale);
    this.localeService.use('pl');
  }


  pobierzIloscZamowien() {

    const dataPoczatkowa = this.formularzZamowienia.get('dataPoczatkowa').value;

    const dataPoczatkowaFormat = this.datepipe.transform(dataPoczatkowa, 'yyyy-MM-dd hh:mm:ss');

    const dataKoncowa = this.formularzZamowienia.get('dataKoncowa').value;

    const dataKoncowaFormat = this.datepipe.transform(dataKoncowa, 'yyyy-MM-dd hh:mm:ss');


    this.zamowieniaService.zliczZamowieniaDoRaportu(dataPoczatkowaFormat, dataKoncowaFormat).subscribe((iloscZamowien: number) => {
      this.iloscZamowien = iloscZamowien;
    }, error => {
      this.alertService.danger('Błąd przy zliczaniu zamówień');
    });
  }


  pobierzIloscKlientow() {

    const dataPoczatkowa = this.formularzKlienci.get('dataPoczatkowa').value;

    const dataPoczatkowaFormat = this.datepipe.transform(dataPoczatkowa, 'yyyy-MM-dd hh:mm:ss');

    const dataKoncowa = this.formularzKlienci.get('dataKoncowa').value;

    const dataKoncowaFormat = this.datepipe.transform(dataKoncowa, 'yyyy-MM-dd hh:mm:ss');


    this.klienciService.zliczProfileKlientowDoRaportu(dataPoczatkowaFormat, dataKoncowaFormat).subscribe((iloscKlientow: number) => {
      this.iloscKlientow = iloscKlientow;
    }, error => {
      this.alertService.danger('Błąd przy zliczaniu klientów');
    });
  }

}
