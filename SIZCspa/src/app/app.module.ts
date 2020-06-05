import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { PanelGornyComponent } from './panel-gorny/panel-gorny.component';
import { PanelBocznyComponent } from './panel-boczny/panel-boczny.component';
import { AutoryzacjaService } from './_serwisy/autoryzacja.service';
import { StronaGlownaComponent } from './strona-glowna/strona-glowna.component';
import { RejestracjaComponent } from './rejestracja/rejestracja.component';

@NgModule({
   declarations: [
      AppComponent,
      MenuComponent,
      PanelGornyComponent,
      PanelBocznyComponent,
      StronaGlownaComponent,
      RejestracjaComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      AutoryzacjaService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
