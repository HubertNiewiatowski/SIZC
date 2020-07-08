import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SidebarModule } from 'ng-sidebar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlertModule } from 'ngx-alerts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { registerLocaleData, DatePipe } from '@angular/common';
import localePl from '@angular/common/locales/pl';
registerLocaleData(localePl);

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { MenuKartaComponent } from './menu-karta/menu-karta.component';
import { PanelGornyComponent } from './panel-gorny/panel-gorny.component';
import { PanelBocznyComponent } from './panel-boczny/panel-boczny.component';
import { AutoryzacjaService } from './_serwisy/autoryzacja.service';
import { StronaGlownaComponent } from './strona-glowna/strona-glowna.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { appRoutes } from './routes';
import { PracownikComponent } from './pracownik/pracownik.component';
import { ZamowieniaComponent } from './zamowienia/zamowienia.component';
import { ZamowieniaKartaComponent } from './zamowienia-karta/zamowienia-karta.component';
import { PracownikKartaComponent } from './pracownik-karta/pracownik-karta.component';
import { PracownikEdytujComponent } from './pracownik-edytuj/pracownik-edytuj.component';
import { ZamowienieEdytujComponent } from './zamowienie-edytuj/zamowienie-edytuj.component';
import { RejestracjaPracownikComponent } from './rejestracja-pracownik/rejestracja-pracownik.component';
import { MenuEdytujComponent } from './menu-edytuj/menu-edytuj.component';
import { RaportyComponent } from './raporty/raporty.component';


export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      PanelGornyComponent,
      PanelBocznyComponent,
      StronaGlownaComponent,
      LogowanieComponent,
      PracownikComponent,
      MenuComponent,
      MenuKartaComponent,
      MenuEdytujComponent,
      ZamowieniaComponent,
      ZamowieniaKartaComponent,
      PracownikKartaComponent,
      PracownikEdytujComponent,
      ZamowienieEdytujComponent,
      RejestracjaPracownikComponent,
      RaportyComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      SidebarModule.forRoot(),
      BrowserAnimationsModule,
      AlertModule.forRoot({maxMessages: 5, timeout: 90000, position: 'right'}),
      BsDatepickerModule.forRoot(),
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['http://localhost:5000/api/AutoryzacjaPracownik/zaloguj']
         }
      })
   ],
   providers: [
      AutoryzacjaService,
      { provide: LOCALE_ID, useValue: 'pl-PL' },
      [DatePipe]
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
