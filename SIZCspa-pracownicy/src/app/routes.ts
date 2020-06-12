import { Routes } from '@angular/router';
import { StronaGlownaComponent } from './strona-glowna/strona-glowna.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { AutoryzacjaGuard } from './_guards/autoryzacja.guard';

export const appRoutes: Routes = [
    { path: 'stronaGlowna', component: StronaGlownaComponent },
    { path: 'logowanie', component: LogowanieComponent },
    { path: '**', redirectTo: 'stronaGlowna', pathMatch: 'full' }
];