import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUsers } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class ClientAccountService {
baseUrl="https://localhost:5001/api/";
  constructor(private http: HttpClient) { }


getUser(userId:number) {
  const params = new HttpParams()
  .set('id', userId)
  
  return this.http.get<IUsers[]>(this.baseUrl + 'myaccount/user',{params});
}

}