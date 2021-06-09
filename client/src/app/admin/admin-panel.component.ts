import { Component, OnInit } from '@angular/core';
import { IGenre } from 'src/app/shared/models/genres';
import { ShopService } from 'src/app/_services/shop.service';
import { IProduct } from '../shared/models/product';
import { IClient } from '../shared/models/client';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {
  genres: IGenre[];
  clients: IClient[];
  isGenreActivated: boolean = false;
  products: IProduct[];
  isProductActivated: boolean = false;
  isClientActivated: boolean = false;
  isOrderActivated: boolean = false;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
  }
  
  toggleGenreMode() {
    this.deactivateAll();
    this.isGenreActivated = true;
   // this.getGenres();
  }
  
  toggleClientsMode() {
    this.deactivateAll();
    this.isClientActivated = true;
    this.getUsers();
  }

  getUsers() {
    this.shopService.getUsers().subscribe(response => {
      this.clients = response;
    }, error => {
      console.log(error);
    });
  }

  toggleProductMode() {
    this.deactivateAll();
    this.isProductActivated=true;
  }

  toggleOrderMode() {
    this.deactivateAll();
    this.isOrderActivated=true;
  }
 

  deactivateAll() {
    this.isGenreActivated = false;
    this.isProductActivated = false;
    this.isClientActivated = false;
    this.isOrderActivated = false;
  }

}
