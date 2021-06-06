import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-account',
  templateUrl: './client-account.component.html',
  styleUrls: ['./client-account.component.scss']
})
export class ClientAccountComponent implements OnInit {

  isOrdersActive: boolean = false;
  
  constructor() { }

  ngOnInit(): void {
  }

  toggleOrdersActive() {
    this.deactivateAll();
    this.isOrdersActive = !this.isOrdersActive;
  }
  

  deactivateAll() {
    this.isOrdersActive = false;
  }
}
