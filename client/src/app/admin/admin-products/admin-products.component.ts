import { Component, OnInit, Input } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.scss']
})
export class AdminProductsComponent implements OnInit {
  @Input() products: IProduct[];
  showProductInfo: number;
  constructor() { }

  ngOnInit(): void {
  }

showProduct(id:number){
  this.showProductInfo= id;
}

closeProductInfo(){
this.showProductInfo = null;
}

}
