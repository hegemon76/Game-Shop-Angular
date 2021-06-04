import { Component, OnInit } from '@angular/core';
import { IGenre } from '../shared/models/genres';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  genres: IGenre[];
  genreNameSelected = 'Wszystkie';
  totalCount:number;

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getGenres();
  }

  getProducts() {
    this.shopService.getProducts(this.genreNameSelected).subscribe(response => {
      this.products = response.items;
      this.totalCount = response.totalItemsCount;
    }, error => {
      console.log(error);
    });
  }

  getGenres() {
    this.shopService.getGenres().subscribe(response => {
      this.genres = [{id:0, name: 'Wszystkie'}, ... response];
    }, error => {
      console.log(error);
    });
  }

  onGenreSelected(genreName:string){
    this.genreNameSelected = genreName;
    this.getProducts();
  }

}
