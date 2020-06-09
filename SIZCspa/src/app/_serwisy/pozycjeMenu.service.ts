import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PozycjaMenu } from '../_models/pozycjaMenu';

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

  pobierzPozycjeMenu(): Observable<PozycjaMenu[]> {
    return this.http.get<PozycjaMenu[]>(this.baseUrl, httpOptions);
  }

  pobierzPozycjeMenuPoId(id): Observable<PozycjaMenu> {
    return this.http.get<PozycjaMenu>(this.baseUrl + id, httpOptions);
  }
}
