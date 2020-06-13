import { Routes } from '@angular/router';
import { StronaGlownaComponent } from './strona-glowna/strona-glowna.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { MenuComponent } from './menu/menu.component';
import { ZamowieniaComponent } from './zamowienia/zamowienia.component';
import { AutoryzacjaGuard } from './_guards/autoryzacja.guard';
import { MenuEdytujComponent } from './menu-edytuj/menu-edytuj.component';
import { PracownikComponent } from './pracownik/pracownik.component';


export const appRoutes: Routes = [
    { path: 'stronaGlowna', component: StronaGlownaComponent },
    { path: 'logowanie', component: LogowanieComponent },
    { path: 'pracownicy', component: PracownikComponent, canActivate: [AutoryzacjaGuard]},
    { path: 'menu', component: MenuComponent, canActivate: [AutoryzacjaGuard]},
    { path: 'edytuj/:id', component: MenuEdytujComponent, canActivate: [AutoryzacjaGuard]},
    { path: 'zamowienia', component: ZamowieniaComponent, canActivate: [AutoryzacjaGuard]},
    { path: '**', redirectTo: 'stronaGlowna', pathMatch: 'full' }
];
