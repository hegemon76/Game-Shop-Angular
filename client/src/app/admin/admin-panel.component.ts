import { Component, OnInit } from '@angular/core';
import { IGenre } from 'src/app/shared/models/genres';
import { ShopService } from 'src/app/shop/shop.service';
import { IProduct } from '../shared/models/product';
import { IUsers } from '../shared/models/user';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {
  genres: IGenre[];
  users: IUsers[];
  isGenreActivated: boolean = false;
  products: IProduct[];
  isProductActivated: boolean = false;
  isClientActivated: boolean = false;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
  }
  
  toggleGenreMode() {
    this.deactivateAll();
    this.isGenreActivated = true;
    this.getGenres();
  }
  
  toggleClientsMode() {
    this.deactivateAll();
    this.isClientActivated = true;
    this.getUsers();
  }

  
  getGenres() {
    this.shopService.getGenres().subscribe(response => {
      this.genres = response;
    }, error => {
      console.log(error);
    });
  }

  getUsers() {
    this.shopService.getUsers().subscribe(response => {
      this.users = response;
    }, error => {
      console.log(error);
    });
  }

  toggleProductMode() {
    this.deactivateAll();
    this.isProductActivated=true;
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts('Wszystkie', 'name').subscribe(response => {
      this.products = response.items;
    }, error => {
      console.log(error);
    });
  }

  deactivateAll() {
    this.isGenreActivated = false;
    this.isProductActivated = false;
    this.isClientActivated = false;
  }

}
