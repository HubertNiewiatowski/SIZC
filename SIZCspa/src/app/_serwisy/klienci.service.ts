import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzKlient } from '../_models/pobierzKlient';

@Injectable({
  providedIn: 'root'
})

export class KlienciService {
  baseUrl = 'http://localhost:5000/api/ProfilKlienta/';

constructor(private http: HttpClient) { }

pobierzKlienta(id): Observable<PobierzKlient> {
  return this.http.get<PobierzKlient>(this.baseUrl + id);
}

}
