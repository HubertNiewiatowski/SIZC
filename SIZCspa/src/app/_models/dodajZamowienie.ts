export interface DodajZamowienie {
    koszt: number;
    kodPocztowy: string;
    miejscowosc: string;
    ulica: string;
    nrBudynek: string;
    nrMieszkanie: string;
    dataRealizacji: Date;
    dataZlozenia?: Date;
    pozycjaMenuID: number;
    klientID: number;
    pracownikID?: number;
    platnoscTypID: number;
    zamowienieStatusID?: number;
}
