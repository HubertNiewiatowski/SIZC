import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Zamowienie } from '../_models/zamowienie';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ZamowieniaService {
  baseUrl = 'http://localhost:5000/api/Zamowienia/klient/';

  constructor(private http: HttpClient) { }

  pobierzZamowienia(id): Observable<Zamowienie[]> {
    return this.http.get<Zamowienie[]>(this.baseUrl + id, httpOptions);
  }

}
