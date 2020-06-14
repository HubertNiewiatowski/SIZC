import { Routes } from '@angular/router';
import { StronaGlownaComponent } from './strona-glowna/strona-glowna.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { MenuComponent } from './menu/menu.component';
import { ZamowieniaComponent } from './zamowienia/zamowienia.component';
import { PracownikRolaService } from './_guards/pracownikRola.service';
import { MenuEdytujComponent } from './menu-edytuj/menu-edytuj.component';
import { PracownikComponent } from './pracownik/pracownik.component';
import { AutoryzacjaGuard } from './_guards/autoryzacja.guard';
import { PracownikEdytujComponent } from './pracownik-edytuj/pracownik-edytuj.component';
import { RejestracjaPracownikComponent } from './rejestracja-pracownik/rejestracja-pracownik.component';



export const appRoutes: Routes = [
    { path: 'stronaGlowna', component: StronaGlownaComponent },
    { path: 'logowanie', component: LogowanieComponent },
    { path: 'pracownicy', component: PracownikComponent, canActivate: [PracownikRolaService], data: {rolaPracownika: '3'}},
    { path: 'pracownicy/edytuj/:id', component: PracownikEdytujComponent, canActivate: [PracownikRolaService], data: {rolaPracownika: '3'}},
    { path: 'pracownicy/rejestruj', component: RejestracjaPracownikComponent,
    canActivate: [PracownikRolaService], data: {rolaPracownika: '3'}},
    { path: 'menu', component: MenuComponent, canActivate: [PracownikRolaService], data: {rolaPracownika: '3'}},
    { path: 'menu/edytuj/:id', component: MenuEdytujComponent, canActivate: [PracownikRolaService], data: {rolaPracownika: '3'}},
    { path: 'zamowienia', component: ZamowieniaComponent, canActivate: [AutoryzacjaGuard]},
    { path: '**', redirectTo: 'stronaGlowna', pathMatch: 'full' }
];
