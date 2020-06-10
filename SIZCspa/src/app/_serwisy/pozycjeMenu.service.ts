import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzPozycjaMenu } from '../_models/pobierzPozycjaMenu';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class PozycjeMenuService {
  baseUrl = 'http://localhost:5000/api/PozycjeMenu/';

  constructor(private http: HttpClient) { }

  pobierzPozycjeMenu(): Observable<PobierzPozycjaMenu[]> {
    return this.http.get<PobierzPozycjaMenu[]>(this.baseUrl, httpOptions);
  }

  pobierzPozycjeMenuPoId(id): Observable<PobierzPozycjaMenu> {
    return this.http.get<PobierzPozycjaMenu>(this.baseUrl + id, httpOptions);
  }
}
