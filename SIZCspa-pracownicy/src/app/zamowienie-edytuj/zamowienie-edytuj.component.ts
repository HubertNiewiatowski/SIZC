import { Component, OnInit } from '@angular/core';
import { ZamowieniaService } from '../_serwisy/zamowienia.service';
import { AlertService } from 'ngx-alerts';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

import { AktualizujZamowienie } from '../_models/aktualizujZamowienie';
import { DlaZamowienieZamowienieStatus } from '../_models/dlaZamowienieZamowienieStatus';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Component({
  selector: 'app-zamowienie-edytuj',
  templateUrl: './zamowienie-edytuj.component.html',
  styleUrls: ['./zamowienie-edytuj.component.css']
})
export class ZamowienieEdytujComponent implements OnInit {
  zamowienie: AktualizujZamowienie = {} as AktualizujZamowienie;
  formularzZamowienia: FormGroup;
  statusyZamowien: DlaZamowienieZamowienieStatus[] = [];
  pracownikRolaId: string;

  constructor(private zamowieniaService: ZamowieniaService, private alertService: AlertService,
              private route: ActivatedRoute, private router: Router, public autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
    this.pobierzZamowienie();

    this.pobierzStatusyZamowien();

    this.pracownikRolaId = this.autoryzacja.decodedToken?.PracownikRolaId;
    this.rolaKucharz();
    this.rolaDostawca();


    // this.statusyZamowien.push({zamowienieStatusID: 1, nazwaStatus: 'zamówione'});
    // this.statusyZamowien.push({zamowienieStatusID: 2, nazwaStatus: 'w trakcie przygotowywania'});
    // this.statusyZamowien.push({zamowienieStatusID: 3, nazwaStatus: 'przygotowane'});
    // this.statusyZamowien.push({zamowienieStatusID: 4, nazwaStatus: 'w trakcie dostawy'});
    // this.statusyZamowien.push({zamowienieStatusID: 5, nazwaStatus: 'dostarczone'});

    this.formularzZamowienia = new FormGroup({

      zamowienieStatus: new FormControl()

    });
  }

  pobierzZamowienie() {
    this.zamowieniaService.pobierzZamowienieDoAktualizacji(+this.route.snapshot.params.id).subscribe((zamowienie: AktualizujZamowienie) => {
      this.zamowienie = zamowienie;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu pozycji');
    });
  }

  pobierzStatusyZamowien() {
    this.zamowieniaService.pobierzStatusyZamowien().subscribe((statusyZamowien: DlaZamowienieZamowienieStatus[]) => {
      this.statusyZamowien = statusyZamowien;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu typów płatności');
    });
  }

  aktualizujZamowienie() {
    this.zamowienie.zamowienieStatusID = this.formularzZamowienia.get('zamowienieStatus').value;

    if (this.zamowienie.zamowienieStatusID === 1 ||
        this.zamowienie.zamowienieStatusID === 2)
    {
      this.zamowienie.pracownikID = 1;
    }

    if (this.zamowienie.zamowienieStatusID === 3 ||
        this.zamowienie.zamowienieStatusID === 4 ||
        this.zamowienie.zamowienieStatusID === 5)
    {
      this.zamowienie.pracownikID = 2;
    }

    if (this.formularzZamowienia.valid) {
      this.zamowieniaService.aktualizujZamowienie(this.zamowienie, +this.route.snapshot.params.id).subscribe(next => {
        this.alertService.success('Zaktualizowano status zamówienia');
      }, error => {
        this.alertService.danger('Błąd w trakcie aktualizowania zamówienia');
      }, () => {
        this.router.navigate(['/zamowienia']);
      });
    }
    else
    {
      this.alertService.danger('Błędnie uzupełniony status zamówienia');
    }
  }

  wyslijEmail() {
    this.zamowieniaService.wyslijEmail(this.zamowienie.klientID, this.zamowienie.zamowienieID).subscribe(next => {
      this.alertService.success('Wysłano powiadomienie mailowe do klienta');
    }, error => {
      this.alertService.danger('Błąd w trakcie wysyłania maila do klienta');
    });
  }

  anuluj() {
    this.alertService.info('Anulowano edycję zamówienia');
    this.router.navigate(['/zamowienia']);
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
