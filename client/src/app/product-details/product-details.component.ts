import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IGenre } from '../shared/models/genres';
import { IOpinion } from '../shared/models/opinion';
import { IProduct } from '../shared/models/product';
import { ShopService } from '../_services/shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  opinions: IOpinion[];
  genre: string;

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
    this.loadOpinions();
  }

  loadProduct() {
    this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
      this.genre = product.genre;
    }, error => {
      console.log(error);
    });
  }

  loadOpinions(){
    this.shopService.getOpinions(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(items => {
      if(items.items != null){
        this.opinions = items.items;
      }
      
    }, error => {
      console.log(error);
    })
  }

}
