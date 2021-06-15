import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUrl=environment.apiUrl;
  
constructor(private http:HttpClient) { }


register(form: any): any {
  return this.http.post(this.baseUrl + "account/register", form);
}

login(form:any): any {
  return this.http.post(this.baseUrl + "account/login", form, {withCredentials: true})
}

logout():void{
 
}
}