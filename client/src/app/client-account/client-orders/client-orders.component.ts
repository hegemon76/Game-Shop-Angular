import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-orders',
  templateUrl: './client-orders.component.html',
  styleUrls: ['./client-orders.component.scss']
})
export class ClientOrdersComponent implements OnInit {
  isShowOrder:boolean=false;
  constructor() { }

  ngOnInit(): void {
  }

  toggleShowOrder(){
    this.isShowOrder = !this.isShowOrder;
  }
  deactivateAll() {
    this.isShowOrder = false;
  }

}
