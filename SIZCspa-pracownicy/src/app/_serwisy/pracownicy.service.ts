import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzPracownik } from '../_models/pobierzPracownik';

@Injectable({
  providedIn: 'root'
})

export class PracownicyService {

  // 1
  baseUrl = 'http://localhost:5000/api/ProfilPracownika/';

  // 2
  constructor(private http: HttpClient) { }

  // 3
  pobierzProfilePracownikowWszystkie(): Observable<PobierzPracownik[]> {

    // 4
    return this.http.get<PobierzPracownik[]>(this.baseUrl);
  }

  // 5
  pobierzProfilPracownikaPoId(id: number): Observable<PobierzPracownik> {

    // 6
    return this.http.get<PobierzPracownik>(this.baseUrl + id);
  }

  // 7
  usunProfilPracownika(id: number): Observable<{}> {

    // 8
    return this.http.delete(this.baseUrl + id);
  }
}
