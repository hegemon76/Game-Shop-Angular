import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IGenre } from '../shared/models/genres';
import { IOpinion } from '../shared/models/opinion';
import { IProduct } from '../shared/models/product';
import { ShopService } from '../shop/shop.service';

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
      this.opinions = items.items;
    }, error => {
      console.log(error);
    })
  }

  loadOpinions2(id:number){
    this.shopService.getOpinions(id).subscribe(response => {
      this.opinions = response.items;
     // console.log(response[].description);
      console.log(this.opinions);
    }, error => {
      console.log(error);
    })
  }

}
