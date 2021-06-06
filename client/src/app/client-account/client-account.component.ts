import { Component, OnInit } from '@angular/core';
import { IUsers } from '../shared/models/user';
import { ShopService } from '../shop/shop.service';

@Component({
  selector: 'app-client-account',
  templateUrl: './client-account.component.html',
  styleUrls: ['./client-account.component.scss']
})
export class ClientAccountComponent implements OnInit {
  users: IUsers[];
  isMyDataActivated: boolean = false;
  isOrdersActive: boolean = false;
  constructor(private shopService: ShopService) { }
  
  

  ngOnInit(): void {
  }
  
  toggleMyDataMode() {
    this.deactivateAll();
    this.isMyDataActivated = true;
    this.getUsers();
  }

  

  getUsers() {
    this.shopService.getUsers().subscribe(response => {
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
