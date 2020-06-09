import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { SidebarModule } from 'ng-sidebar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlertModule } from 'ngx-alerts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { PanelGornyComponent } from './panel-gorny/panel-gorny.component';
import { PanelBocznyComponent } from './panel-boczny/panel-boczny.component';
import { AutoryzacjaService } from './_serwisy/autoryzacja.service';
import { StronaGlownaComponent } from './strona-glowna/strona-glowna.component';
import { RejestracjaComponent } from './rejestracja/rejestracja.component';
import { ZamowieniaComponent } from './zamowienia/zamowienia.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { appRoutes } from './routes';
import { KlientComponent } from './klient/klient.component';
import { MenuKartaComponent } from './menu-karta/menu-karta.component';
import { ZamowieniaKartaComponent } from './zamowienia-karta/zamowienia-karta.component';

@NgModule({
   declarations: [
      AppComponent,
      MenuComponent,
      PanelGornyComponent,
      PanelBocznyComponent,
      StronaGlownaComponent,
      RejestracjaComponent,
      ZamowieniaComponent,
      LogowanieComponent,
      KlientComponent,
      MenuKartaComponent,
      ZamowieniaKartaComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      SidebarModule.forRoot(),
      BrowserAnimationsModule,
      AlertModule.forRoot({maxMessages: 5, timeout: 2000, position: 'right'}),
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AutoryzacjaService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
