import { Component, OnInit } from '@angular/core';
import { PracownicyService } from '../_serwisy/pracownicy.service';
import { PobierzPracownik } from '../_models/pobierzPracownik';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-pracownik',
  templateUrl: './pracownik.component.html',
  styleUrls: ['./pracownik.component.css']
})
export class PracownikComponent implements OnInit {
  profilePracownikow: PobierzPracownik[];

  constructor(private alertService: AlertService,
              private pracownicyService: PracownicyService) { }

  ngOnInit() {
    this.pobierzPracownikow();
  }

  pobierzPracownikow() {
    this.pracownicyService.pobierzProfilePracownikowWszystkie().subscribe((profilePracownikow: PobierzPracownik[]) => {
      this.profilePracownikow = profilePracownikow;
    }, error => {
      this.alertService.danger('Błąd przy pobieraniu profili pracowników');
    });
  }

}
