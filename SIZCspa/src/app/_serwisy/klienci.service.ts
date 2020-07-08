import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzKlient } from '../_models/pobierzKlient';

@Injectable({
  providedIn: 'root'
})

export class KlienciService {
  baseUrl = 'http://localhost:5000/api/ProfilKlienta/';

constructor(private http: HttpClient) { }

  pobierzProfilKlienta(id: number): Observable<PobierzKlient> {
    return this.http.get<PobierzKlient>(this.baseUrl + id);
  }

  aktualizujProfilKlienta(klient: PobierzKlient, id: number): Observable<PobierzKlient> {
    return this.http.put<PobierzKlient>(this.baseUrl + id, klient);
  }

  usunProfilKlienta(id: number): Observable<{}> {
    return this.http.delete(this.baseUrl + id);
  }
}
