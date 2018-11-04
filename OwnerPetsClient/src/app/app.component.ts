import { Observable } from 'rxjs';
import { PetDataServiceService } from './pet-data-service.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'OwnerPetsClient';

  public result;
  
  constructor(private _petservice : PetDataServiceService ){
   this.result = _petservice.getPetsData(); 
  }
}
