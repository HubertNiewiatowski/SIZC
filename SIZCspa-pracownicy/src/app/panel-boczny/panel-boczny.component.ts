import { Component, OnInit } from '@angular/core';
import { AutoryzacjaService } from '../_serwisy/autoryzacja.service';

@Component({
  selector: 'app-panel-boczny',
  templateUrl: './panel-boczny.component.html',
  styleUrls: ['./panel-boczny.component.css']
})
export class PanelBocznyComponent implements OnInit {

  pracownikRolaId: string;
  opened = true;

  constructor(public autoryzacja: AutoryzacjaService) { }

  ngOnInit() {
    this.pracownikRolaId = this.autoryzacja.decodedToken?.PracownikRolaId;
    this.rolaPracownik();
    this.rolaAdministrator();
  }

  rolaPracownik() {
    if (this.pracownikRolaId === '1' || this.pracownikRolaId === '2')
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  rolaAdministrator() {
    if (this.pracownikRolaId === '3')
    {
      return true;
    }
    else
    {
      return false;
    }
  }



  zalogowany() {
    return this.autoryzacja.zalogowany();
  }


  toggleSidebar() {
    this.opened = !this.opened;
  }

}
