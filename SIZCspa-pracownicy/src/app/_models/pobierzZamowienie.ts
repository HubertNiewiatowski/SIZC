import { DlaZamowieniePozycjaMenu } from './dlaZamowieniePozycjaMenu';
import { DlaZamowieniePlatnoscTyp } from './dlaZamowieniePlatnoscTyp';
import { DlaZamowienieZamowienieStatus } from './dlaZamowienieZamowienieStatus';

export interface PobierzZamowienie {
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
    klientID: number;
    pracownikID: number;
    platnoscTyp: DlaZamowieniePlatnoscTyp;
    zamowienieStatus: DlaZamowienieZamowienieStatus;
}
