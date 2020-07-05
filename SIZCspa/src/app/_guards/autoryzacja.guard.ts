import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';
import { AlertService } from 'ngx-alerts';

@Injectable({
  providedIn: 'root'
})
export class AutoryzacjaGuard implements CanActivate {
  constructor(private autoryzacja: AutoryzacjaService, private router: Router,  private alertService: AlertService) {}

  canActivate(): boolean {
    if (this.autoryzacja.zalogowany()) {
      return true;
    }

    this.alertService.warning('Operacja dostępna dla zalogowanych użytkowników');
    this.router.navigate(['/stronaGlowna']);
    return false;
  }
}
