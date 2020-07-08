import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzZamowienie } from '../_models/pobierzZamowienie';
import { DodajZamowienie } from '../_models/dodajZamowienie';
import { DlaZamowieniePlatnoscTyp } from '../_models/dlaZamowieniePlatnoscTyp';

@Injectable({
  providedIn: 'root'
})

export class ZamowieniaService {
  baseUrl = 'http://localhost:5000/api/Zamowienia/';

  constructor(private http: HttpClient) { }

  pobierzZamowieniaKlienta(id: number): Observable<PobierzZamowienie[]> {
    return this.http.get<PobierzZamowienie[]>(this.baseUrl + 'klient/' + id);
  }

  dodajZamowienieKlienta(zamowienie: DodajZamowienie): Observable<DodajZamowienie> {
    return this.http.post<DodajZamowienie>(this.baseUrl + 'klient/', zamowienie);
  }

  pobierzTypyPlatnosci(): Observable<DlaZamowieniePlatnoscTyp[]> {
    return this.http.get<DlaZamowieniePlatnoscTyp[]>(this.baseUrl + 'platnoscTyp/');
  }


}
