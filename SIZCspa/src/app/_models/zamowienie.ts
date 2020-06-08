import { DlaZamowieniePlatnoscTyp } from './dlaZamowieniePlatnoscTyp';
import { DlaZamowienieZamowienieStatus } from './dlaZamowienieZamowienieStatus';
import { DlaZamowieniePozycjaMenu } from './dlaZamowieniePozycjaMenu';

export interface Zamowienie {
    zamowienieID: number;
    koszt: number;
    kodPocztowy: string;
    miejscowosc: string;
    ulica: string;
    nrBudynek: string;
    nrMieszkanie: string;
    dataRealizacji: Date;
    dataZlozenia: Date;
    pozycjaMenu: DlaZamowieniePozycjaMenu;
    platnoscTyp: DlaZamowieniePlatnoscTyp;
    zamowienieStatus: DlaZamowienieZamowienieStatus;
}
