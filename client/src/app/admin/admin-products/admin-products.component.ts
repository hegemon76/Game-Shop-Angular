import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit, Input } from '@angular/core';
import { IGenre } from 'src/app/shared/models/genres';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from 'src/app/_services/shop.service';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.scss']
})
export class AdminProductsComponent implements OnInit {

  products: IProduct[];
  showProductInfo: number;
  genres: IGenre[];
  isAddMode: boolean = false;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getGenres();
  }

  toggleAddMode() {
    this.isAddMode = !this.isAddMode;
  }
  //#region Product 

  showProduct(id: number) {
    this.showProductInfo = id;
  }

  closeProductInfo() {
    this.showProductInfo = null;
  }

  getProducts() {
    this.shopService.getProducts('Wszystkie', 'name').subscribe(response => {
      this.products = response.items;
    }, error => {
      console.log(error);
    });
  }

  updateProduct(event: any) {
    this.shopService.updateProduct(event.id, event.body).subscribe(response => {
      if (response) {
        this.ngOnInit();
      }
    });
  }

  addProduct(event: any) {
    this.shopService.addProduct(event).subscribe(response => {
      if (response) {
        console.log(response);
      }
    }, error => {
      console.log(error);
    });
    this.toggleAddMode();
  }

  deleteProduct(event: number) {
    this.shopService.deleteProduct(event).subscribe(response => {
      this.ngOnInit();
    }, error => {
      console.log(error);
    });

    this.ngOnInit();
  }
  //#endregion

  //#region Genres
  getGenres() {
    this.shopService.getGenres().subscribe(response => {
      if (response) {
        this.genres = response;
      }

    }, error => {
      console.log(error);
    });
  }
  //#endregion
}
