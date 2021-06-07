import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IClient} from '../shared/models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientAccountService {
baseUrl=environment.apiUrl;
  constructor(private http: HttpClient) { }


getUser(userId:number) {
  const params = new HttpParams()
  .set('id', userId)
  
  return this.http.get<IClient>(this.baseUrl + 'myaccount/user',{params});
}

}