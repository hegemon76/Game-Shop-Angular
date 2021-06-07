import { Component, OnInit } from '@angular/core';
import { IClient } from '../shared/models/client';
import { ClientAccountService } from '../_services/client-account.service';

@Component({
  selector: 'app-client-account',
  templateUrl: './client-account.component.html',
  styleUrls: ['./client-account.component.scss']
})
export class ClientAccountComponent implements OnInit {
  client: IClient;
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
      this.client = response;
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
