import { Component, OnInit } from '@angular/core';
import { IUsers } from '../shared/models/user';
import { ClientAccountService } from './client-account.service';

@Component({
  selector: 'app-client-account',
  templateUrl: './client-account.component.html',
  styleUrls: ['./client-account.component.scss']
})
export class ClientAccountComponent implements OnInit {
  users: IUsers[];
  isMyDataActivated: boolean = false;
  isOrdersActive: boolean = false;
  
  constructor(private clientAccountService: ClientAccountService) { }
  
  ngOnInit(): void {
  }
  
  toggleMyDataMode() {
    this.deactivateAll();
    this.isMyDataActivated = true;
    this.getUser(1);
  }

  getUser(id:number) {
    this.clientAccountService.getUser(id).subscribe(response => {
      this.users = response;
    }, error => {
      console.log(error);
    });
  }
  
    toggleOrdersActive() {
    this.deactivateAll();
    this.isOrdersActive = true;
  }
  
  deactivateAll() {
    this.isOrdersActive = false;
    this.isMyDataActivated =false;
  }
}
