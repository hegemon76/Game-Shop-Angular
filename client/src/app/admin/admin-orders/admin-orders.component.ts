import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-orders',
  templateUrl: './admin-orders.component.html',
  styleUrls: ['./admin-orders.component.scss']
})
export class AdminOrdersComponent implements OnInit {
  isShowOrder: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  toggleShowOrder() {
    this.isShowOrder = !this.isShowOrder;
  }
}
