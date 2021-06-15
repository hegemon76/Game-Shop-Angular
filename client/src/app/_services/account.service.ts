import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { IClient } from '../shared/models/client';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private currentUserSource = new ReplaySubject<IClient>(1);
  currentUser$ = this.currentUserSource.asObservable();

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

getUser(){
  var user = JSON.parse(localStorage.getItem('user'));
  return user;
}


  register(form: any): any {
    return this.http.post(this.baseUrl + "account/register", form);
  }

  login(form: any): any {
    return this.http.post(this.baseUrl + "account/login", form, { withCredentials: false }).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
          return user;
        }
      })
    )
  }

  logout(): void {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}