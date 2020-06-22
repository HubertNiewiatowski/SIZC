import { Routes } from '@angular/router';
import { StronaGlownaComponent } from './strona-glowna/strona-glowna.component';
import { RejestracjaComponent } from './rejestracja/rejestracja.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { MenuComponent } from './menu/menu.component';
import { ZamowieniaComponent } from './zamowienia/zamowienia.component';
import { KlientComponent } from './klient/klient.component';
import { AutoryzacjaGuard } from './_guards/autoryzacja.guard';
import { MenuZamowComponent } from './menu-zamow/menu-zamow.component';

export const appRoutes: Routes = [
    { path: 'stronaGlowna', component: StronaGlownaComponent },
    { path: 'rejestracja', component: RejestracjaComponent },
    { path: 'logowanie', component: LogowanieComponent },
    { path: 'menu', component: MenuComponent },
    { path: 'menu/zamow/:id', component: MenuZamowComponent, canActivate: [AutoryzacjaGuard]},
    { path: 'zamowienia', component: ZamowieniaComponent, canActivate: [AutoryzacjaGuard]},
    { path: 'klient', component: KlientComponent, canActivate: [AutoryzacjaGuard]},
    { path: '**', redirectTo: 'stronaGlowna', pathMatch: 'full' }
];
