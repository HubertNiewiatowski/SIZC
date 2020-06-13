import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';

@Injectable({
  providedIn: 'root'
})
export class PozycjeMenuService {
  baseUrl = 'http://localhost:5000/api/PozycjeMenu/';

  constructor(private http: HttpClient) { }

  pobierzPozycjeMenuWszystkie(): Observable<PobierzPozycjaMenu[]> {
    return this.http.get<PobierzPozycjaMenu[]>(this.baseUrl);
  }

  pobierzPozycjeMenuPoId(id): Observable<PobierzPozycjaMenu> {
    return this.http.get<PobierzPozycjaMenu>(this.baseUrl + id);
  }

  dodajPozycjeMenu(pozycja: PobierzPozycjaMenu): Observable<PobierzPozycjaMenu> {
    return this.http.post<PobierzPozycjaMenu>(this.baseUrl, pozycja);
  }

  aktualizujPozycjeMenu(pozycja: PobierzPozycjaMenu, id): Observable<PobierzPozycjaMenu> {
    return this.http.put<PobierzPozycjaMenu>(this.baseUrl + id, pozycja);
  }

  usunPozycjeMenu(id): Observable<{}> {
    return this.http.delete(this.baseUrl + id);
  }

}
