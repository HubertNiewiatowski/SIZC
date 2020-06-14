import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PobierzPracownik } from '../_models/pobierzPracownik';

@Injectable({
  providedIn: 'root'
})
export class PracownicyService {
  baseUrl = 'http://localhost:5000/api/ProfilPracownika/';
  constructor(private http: HttpClient) { }

pobierzProfilePracownikowWszystkie(): Observable<PobierzPracownik[]> {
  return this.http.get<PobierzPracownik[]>(this.baseUrl);
}

pobierzProfilPracownikaPoId(id): Observable<PobierzPracownik> {
  return this.http.get<PobierzPracownik>(this.baseUrl + id);
}

aktualizujProfilPracownika(pracownik: PobierzPracownik, id): Observable<PobierzPracownik> {
  return this.http.put<PobierzPracownik>(this.baseUrl + id, pracownik);
}

usunProfilPracownika(id): Observable<{}> {
  return this.http.delete(this.baseUrl + id);
}

}
