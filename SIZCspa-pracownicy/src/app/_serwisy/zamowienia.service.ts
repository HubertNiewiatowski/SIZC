import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzZamowienie } from '../_models/pobierzZamowienie';

@Injectable({
  providedIn: 'root'
})
export class ZamowieniaService {
  baseUrl = 'http://localhost:5000/api/Zamowienia/';

  constructor(private http: HttpClient) { }

  pobierzZamowieniaPracownika(id): Observable<PobierzZamowienie[]> {
    return this.http.get<PobierzZamowienie[]>(this.baseUrl + 'pracownik/' + id);
  }

  pobierzZamowieniaWszystkie(): Observable<PobierzZamowienie[]> {
    return this.http.get<PobierzZamowienie[]>(this.baseUrl);
  }

  pobierzZamowieniePoId(id): Observable<PobierzZamowienie> {
    return this.http.get<PobierzZamowienie>(this.http + id);
  }

  aktualizujZamowienie(zamowienie: PobierzZamowienie, id) {
    return this.http.put<PobierzZamowienie>(this.http + id, zamowienie);
  }

}
