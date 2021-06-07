import { Component, OnInit } from '@angular/core';
import { IGenre } from '../shared/models/genres';
import { IOpinion } from '../shared/models/opinion';
import { IProduct } from '../shared/models/product';
import { ShopService } from '../_services/shop.service';

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
  itemsFrom:number;
  itemsTo:number;
  sortSelected = 'name';
  searchPhrase:string;
  sortOption = [
    {name: 'Alfabetycznie', value: 'Name'},
    {name: 'Cena: Rosnąco', value: 'PriceAsc'},
    {name: 'Cena: Malejąco', value: 'PriceDesc'}
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getGenres();
  }

  getProducts() {
    this.shopService.getProducts(this.genreNameSelected, this.sortSelected, this.searchPhrase).subscribe(response => {
      this.products = response.items;
      this.itemsFrom=response.itemsFrom;
      this.itemsTo=response.itemsTo;
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

  onSortSelected(sort:string){
    this.sortSelected = sort;
    this.getProducts();
  }
  
  onSearchPhraseModyfied(searchPhrase:string){
    this.searchPhrase = searchPhrase;
    this.getProducts();
  }

}
