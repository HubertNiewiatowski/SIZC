import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})

export class AutoryzacjaService {

  // 1
  baseUrl = 'http://localhost:5000/api/AutoryzacjaKlient/';

  // 2
  jwtHelper = new JwtHelperService();

  // 3
  decodedToken: any;

  // 4
  constructor(private http: HttpClient) { }

  // 5
  zaloguj(klientLogowanie: any) {

    // 6
    return this.http.post(this.baseUrl + 'zaloguj', klientLogowanie)
      .pipe(
        map((odpowiedz: any) => {

          // 7
          const klientModel = odpowiedz;

          // 8
          if (klientModel) {
            localStorage.setItem('token', klientModel.token);
            this.decodedToken = this.jwtHelper.decodeToken(klientModel.token);
        }
      })
    );
  }

  // 1
  zarejestruj(klientRejestracja: any) {

    // 2
    return this.http.post(this.baseUrl + 'zarejestruj', klientRejestracja);
  }


  zalogowany() {

    // 3
    const token = localStorage.getItem('token');

    // 4
    return !this.jwtHelper.isTokenExpired(token);
  }

  wyloguj() {

    // 5
    localStorage.removeItem('token');
  }
}
