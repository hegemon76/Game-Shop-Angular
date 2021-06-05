import { Component, OnInit } from '@angular/core';
import { IGenre } from 'src/app/shared/models/genres';
import { ShopService } from 'src/app/shop/shop.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {
  genres: IGenre[];
  isGenreActivated: boolean = false;
  isProductActivated: boolean = false;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
  }

  getGenres() {
    this.shopService.getGenres().subscribe(response => {
      this.genres = [{ id: 0, name: 'Wszystkie' }, ...response];
    }, error => {
      console.log(error);
    });
  }
  toggleGnereMode() {
    this.deactivateAll();
    this.isGenreActivated = true;
    this.getGenres();
  }
  

  toggleProductMode() {
    this.deactivateAll();
    this.isProductActivated=true;
  }

  deactivateAll() {
    this.isGenreActivated = false;
    this.isProductActivated = false;
  }

}
