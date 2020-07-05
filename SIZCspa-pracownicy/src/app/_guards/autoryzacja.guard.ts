import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlertService } from 'ngx-alerts';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Injectable({
  providedIn: 'root'
})
export class AutoryzacjaGuard implements CanActivate {
  constructor(private autoryzacja: AutoryzacjaService, private router: Router,  private alertService: AlertService) {}

  canActivate(): boolean {
    if (this.autoryzacja.zalogowany()) {
      return true;
    }

    this.alertService.warning('Operacja dostępna dla zalogowanych pracowników');
    this.router.navigate(['/stronaGlowna']);
    return false;
  }
}
