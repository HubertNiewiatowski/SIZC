import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KlienciService {
  baseUrl = 'http://localhost:5000/api/ProfilKlienta/';

constructor(private http: HttpClient) { }

  zliczProfileKlientowDoRaportu(dataPoczatkowa: string, dataKoncowa: string): Observable<number> {
    return this.http.get<number>(this.baseUrl + dataPoczatkowa + '/' + dataKoncowa);
  }

}
