import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzKlient } from '../_models/pobierzKlient';
import { AktualizujKlient } from '../_models/aktualizujKlient';

@Injectable({
  providedIn: 'root'
})

export class KlienciService {
  baseUrl = 'http://localhost:5000/api/ProfilKlienta/';

constructor(private http: HttpClient) { }

  pobierzProfilKlienta(id): Observable<PobierzKlient> {
    return this.http.get<PobierzKlient>(this.baseUrl + id);
  }

  aktualizujProfilKlienta(klient: AktualizujKlient, id): Observable<AktualizujKlient> {
    return this.http.put<AktualizujKlient>(this.baseUrl + id, klient);
  }

  usunProfilKlienta(id): Observable<{}> {
    return this.http.delete(this.baseUrl + id);
  }
}
