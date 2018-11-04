import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})

export class PetDataServiceService {

  

  constructor(private httpClient: HttpClient ) {
    const endpoint = 'http://localhost:64079/api/';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
   }  
  
   private extractData(res: Response) {
      let body = res;
      return body || { };
    }

    getProducts(): Observable<any> {
      return this.httpClient.get('http://localhost:64079/api/pets');
    }

    
}
