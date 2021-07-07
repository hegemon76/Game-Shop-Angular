import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IGenre } from '../shared/models/genres';
import { IOpinion } from '../shared/models/opinion';
import { IProduct } from '../shared/models/product';
import { ShopService } from '../_services/shop.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  opinions: IOpinion[];
  genre: string;

  opinionForm = new FormGroup({
    name: new FormControl(''),
    surname: new FormControl(''),
    description: new FormControl(''),
  });

  onSubmit(name?: number, surname?: string, descriprion?:string, productId?: number ) {
    const body = {
      'name': name,
      'surname': surname,
      'description': descriprion,
    }

    console.log(body);
    console.log(productId);
    this.shopService.addOpinion(productId,body).subscribe(response => {
      if(response){
        this.ngOnInit();
      }
    }, error => {
      console.log(error);
    })
  }
   

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
