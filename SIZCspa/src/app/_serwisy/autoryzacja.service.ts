import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AutoryzacjaService {
  baseUrl = 'http://localhost:5000/api/AutoryzacjaKlient/';

  constructor(private http: HttpClient) { }

  zaloguj(klientLogowanie: any) {
    return this.http.post(this.baseUrl + 'zaloguj', klientLogowanie)
      .pipe(
        map((response: any) => {
          const klientModel = response;
          if (klientModel) {
            localStorage.setItem('token', klientModel.token);
        }
      })
    );
  }

  zarejestruj(klientRejestracja: any) {
    return this.http.post(this.baseUrl + 'zarejestruj', klientRejestracja);
  }
}
