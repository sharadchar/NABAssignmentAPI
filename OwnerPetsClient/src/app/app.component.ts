import { Observable } from 'rxjs';
import { PetDataServiceService } from './pet-data-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  title = 'OwnerPetsClient';

  result ={};
  
  constructor(private _petservice : PetDataServiceService ){
   
  }

  ngOnInit(){
     //called after the constructor and called  after the first ngOnChanges() 
     this.result = this._petservice.getPetsData();
  }

  
  
}
