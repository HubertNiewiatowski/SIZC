import { Component, OnInit } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { PracownicyService } from '../_serwisy/pracownicy.service';
import { PobierzPracownik } from '../_models/pobierzPracownik';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-pracownik-edytuj',
  templateUrl: './pracownik-edytuj.component.html',
  styleUrls: ['./pracownik-edytuj.component.css']
})
export class PracownikEdytujComponent implements OnInit {
  profilPracownika: PobierzPracownik = {} as PobierzPracownik;

  constructor(private alertService: AlertService,
              private pracownicyService: PracownicyService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
  }

  pobierzProfilPracownika() {
    this.pracownicyService.pobierzProfilPracownikaPoId(+this.route.snapshot.params.id).subscribe((profilPracownika: PobierzPracownik) => {
      this.profilPracownika = profilPracownika;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu profilu pracownika');
    });
  }

  usunProfilPracownika() {
    this.pracownicyService.usunProfilPracownika(+this.route.snapshot.params.id).subscribe(next => {
      this.alertService.success('Usunięto profil pracownika');
    }, error => {
      this.alertService.warning('Błąd w trakcie usuwania profilu pracownika');
    }, () => {
      this.router.navigate(['/pracownicy']);
    });
  }

  anuluj() {
    this.alertService.info('Anulowano edycję profilu pracownika');
    this.router.navigate(['/pracownicy']);
  }

}
