import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AutoryzacjaService } from './_serwisy/autoryzacja.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'SIZCspa';
  jwtHelper = new JwtHelperService();

  constructor(private autoryzacja: AutoryzacjaService){}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.autoryzacja.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }
}
