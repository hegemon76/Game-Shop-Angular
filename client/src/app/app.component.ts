import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'client';

  products: IProduct[];

  constructor(private http: HttpClient) {}

  ngOnInit() :void {

    this.http.get<IPagination>('https://localhost:5001/api/videogames/search/?PageSize=5&PageNumber=1').subscribe(
      (response: IPagination) =>{
      this.products = response.items;
      console.log(this.products);
    }, error => {
      console.log(error);
    });
  }

}
