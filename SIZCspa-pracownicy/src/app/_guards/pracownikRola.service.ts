import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';

@Injectable({
  providedIn: 'root'
})
export class PracownikRolaService implements CanActivate {
  jwtHelper = new JwtHelperService();

  constructor(private autoryzacja: AutoryzacjaService, public router: Router, private alertService: AlertService) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {

    const rolaPracownika = route.data.rolaPracownika;
    const token = localStorage.getItem('token');

    this.autoryzacja.decodedToken = this.jwtHelper.decodeToken(token);

    if (!this.autoryzacja.zalogowany() || this.autoryzacja.decodedToken.PracownikRolaId !== rolaPracownika) {
      this.router.navigate(['/stronaGlowna']
      );
      this.alertService.warning('Brak dostępu');
      return false;
    }
    return true;
  }
}
