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

  getProducts() {
    this.shopService.getProducts('Wszystkie', 'name').subscribe(response => {
      this.products = response.items;
    }, error => {
      console.log(error);
    });
  }

  showProduct(id: number) {
    this.showProductInfo = id;
  }

  closeProductInfo() {
    this.showProductInfo = null;
  }

  toggleAddMode() {
    this.isAddMode = !this.isAddMode;
  }

  updateProduct(event: any) {
    this.shopService.updateProduct(event.id, event.body).subscribe(response => {
      if (response) {
        this.ngOnInit();
      }
    });
  }

  

  getGenres() {
    this.shopService.getGenres().subscribe(response => {
      if (response) {
        this.genres = response;
      }

    }, error => {
      console.log(error);
    });
  }

}
