import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUrl=environment.apiUrl;
  constructor(
    private http:HttpClient,
    ) { }


register(form: any): any {
  this.http.post(this.baseUrl + "account/register", form);
}

login(form:any): void {
  this.http.post(this.baseUrl + "account/login", form, {withCredentials: true})
  .subscribe(
    //res=> {
    //console.log(res)
    //this.router.navigate(['/login'])}
  );
}

logout():void{
 
}
}