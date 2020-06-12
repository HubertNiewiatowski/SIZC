import { DlaPozycjaMenuSkladnik } from './dlaPozycjaMenuSkladnik';

export interface PobierzPozycjaMenu {
    pozycjaMenuID: number;
    nazwaPozycja: string;
    cena: number;
    opis: string;
    obrazekUrl: string;
    skladnik?: DlaPozycjaMenuSkladnik[];
}
