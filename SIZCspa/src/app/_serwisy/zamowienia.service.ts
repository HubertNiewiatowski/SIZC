import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzZamowienie } from '../_models/pobierzZamowienie';

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

  pobierzZamowienia(id): Observable<PobierzZamowienie[]> {
    return this.http.get<PobierzZamowienie[]>(this.baseUrl + id, httpOptions);
  }

}
