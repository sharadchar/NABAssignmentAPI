import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})

export class PetDataServiceService {

  

  constructor(private http: HttpClient ) {
    const endpoint = 'http://localhost:64079/api/';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
   }  
  
   getPetsData() {
      return this.http.get('http://localhost:64079/api/pet').subscribe(data=> console.log("we got", data));
    }

    
}
