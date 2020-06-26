import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzZamowienie } from '../_models/pobierzZamowienie';
import { AktualizujZamowienie } from '../_models/aktualizujZamowienie';
import { DlaZamowienieZamowienieStatus } from '../_models/dlaZamowienieZamowienieStatus';

@Injectable({
  providedIn: 'root'
})
export class ZamowieniaService {
  baseUrl = 'http://localhost:5000/api/Zamowienia/';

  constructor(private http: HttpClient) { }

  pobierzZamowieniaPracownika(id): Observable<PobierzZamowienie[]> {
    return this.http.get<PobierzZamowienie[]>(this.baseUrl + 'pracownik/' + id);
  }

  zliczZamowieniaDoRaportu(dataPoczatkowa: string, dataKoncowa: string): Observable<number> {
    return this.http.get<number>(this.baseUrl + dataPoczatkowa + '/' + dataKoncowa);
  }

  pobierzZamowieniePoId(id): Observable<PobierzZamowienie> {
    return this.http.get<PobierzZamowienie>(this.baseUrl + id);
  }

  pobierzZamowienieDoAktualizacji(id): Observable<AktualizujZamowienie> {
    return this.http.get<AktualizujZamowienie>(this.baseUrl + 'aktualizacja/' + id);
  }

  aktualizujZamowienie(zamowienie: AktualizujZamowienie, id) {
    return this.http.put<AktualizujZamowienie>(this.baseUrl + id, zamowienie);
  }

  pobierzStatusyZamowien(): Observable<DlaZamowienieZamowienieStatus[]> {
    return this.http.get<DlaZamowienieZamowienieStatus[]>(this.baseUrl + 'zamowienieStatus/');
  }

}
