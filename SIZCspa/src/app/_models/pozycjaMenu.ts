import { DlaPozycjaMenuSkladnik } from './dlaPozycjaMenuSkladnik';

export interface PozycjaMenu {
    pozycjaMenuID: number;
    nazwaPozycja: string;
    cena: number;
    opis: string;
    obrazekUrl: string;
    skladnik?: DlaPozycjaMenuSkladnik[];
}
