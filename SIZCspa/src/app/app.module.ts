import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { SidebarModule } from 'ng-sidebar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlertModule } from 'ngx-alerts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { PanelGornyComponent } from './panel-gorny/panel-gorny.component';
import { PanelBocznyComponent } from './panel-boczny/panel-boczny.component';
import { AutoryzacjaService } from './_serwisy/autoryzacja.service';
import { StronaGlownaComponent } from './strona-glowna/strona-glowna.component';
import { RejestracjaComponent } from './rejestracja/rejestracja.component';
import { ZamowieniaComponent } from './zamowienia/zamowienia.component';

@NgModule({
   declarations: [
      AppComponent,
      MenuComponent,
      PanelGornyComponent,
      PanelBocznyComponent,
      StronaGlownaComponent,
      RejestracjaComponent,
      ZamowieniaComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      SidebarModule.forRoot(),
      BrowserAnimationsModule,
      AlertModule.forRoot({maxMessages: 5, timeout: 2000, position: 'right'}),
      BsDropdownModule.forRoot()
   ],
   providers: [
      AutoryzacjaService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
