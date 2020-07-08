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

  pobierzPozycjeMenuPoId(id: number): Observable<PobierzPozycjaMenu> {
    return this.http.get<PobierzPozycjaMenu>(this.baseUrl + id);
  }
}
