import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUrl=environment.apiUrl;
  constructor(
    private http:HttpClient,
    private router:Router
    ) { }


register(form: any): void {
  this.http.post(this.baseUrl + "account/register", form)
  .subscribe(res=> {
    console.log(res)
    this.router.navigate(['/login'])
  });
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