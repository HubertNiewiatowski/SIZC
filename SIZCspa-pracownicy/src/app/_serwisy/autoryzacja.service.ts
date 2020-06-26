import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AutoryzacjaService {
  baseUrl = 'http://localhost:5000/api/AutoryzacjaPracownik/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

constructor(private http: HttpClient) { }

  zaloguj(pracownikLogowanie: any) {
    return this.http.post(this.baseUrl + 'zaloguj', pracownikLogowanie)
      .pipe(
        map((response: any) => {
          const pracownikModel = response;
          if (pracownikModel) {
            localStorage.setItem('token', pracownikModel.token);
            this.decodedToken = this.jwtHelper.decodeToken(pracownikModel.token);
        }
      })
    );
  }

  zarejestruj(pracownikRejestracja: any) {
    return this.http.post(this.baseUrl + 'zarejestruj', pracownikRejestracja);
  }

  zalogowany() {
    const token = localStorage.getItem('token');

    return !this.jwtHelper.isTokenExpired(token);
  }

  wyloguj() {
    localStorage.removeItem('token');
  }



}
