import { Component, Input, OnInit } from '@angular/core';
import { delay } from 'rxjs/operators';
import { IGenre } from 'src/app/shared/models/genres';
import { ShopService } from 'src/app/_services/shop.service';

@Component({
  selector: 'app-admin-genre',
  templateUrl: './admin-genre.component.html',
  styleUrls: ['./admin-genre.component.scss']
})
export class AdminGenreComponent implements OnInit {
  isAddGenre: boolean = false;
  genres: IGenre[];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getGenres();
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

  toggleAddGenre() {
    this.isAddGenre = !this.isAddGenre;
  }

  updateGenre(values: any) {
    this.shopService.updateGenre(values.oldValue, values.newValue).subscribe(response => {
      if (response) {
        this.ngOnInit();
      }
    }
    );
  }

  addGenre(value: any) {
    this.shopService.addGenre(value).subscribe(response => {
      if (response) {
        this.toggleAddGenre();
      }
    })
  }

  deleteGenre(value: any) {
    this.shopService.deleteGenre(value).subscribe(response => {
      if (response) {
        this.ngOnInit();
      }
    })
  }

}
