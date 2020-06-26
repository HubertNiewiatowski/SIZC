import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})

export class AutoryzacjaService {
  baseUrl = 'http://localhost:5000/api/AutoryzacjaKlient/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) { }

  zaloguj(klientLogowanie: any) {
    return this.http.post(this.baseUrl + 'zaloguj', klientLogowanie)
      .pipe(
        map((response: any) => {
          const klientModel = response;
          if (klientModel) {
            localStorage.setItem('token', klientModel.token);
            this.decodedToken = this.jwtHelper.decodeToken(klientModel.token);
        }
      })
    );
  }

  zarejestruj(klientRejestracja: any) {
    return this.http.post(this.baseUrl + 'zarejestruj', klientRejestracja);
  }

  zalogowany() {
    const token = localStorage.getItem('token');

    return !this.jwtHelper.isTokenExpired(token);
  }

  wyloguj() {
    localStorage.removeItem('token');
  }
}
