import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IGenre } from '../shared/models/genres';
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators';
import { IProduct } from '../shared/models/product';
import { IOpinion } from '../shared/models/opinion';
import { IOpinionsAPI } from '../shared/models/itemsOpinion';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(genreName?: string, sort?: string) {
    let params = new HttpParams();

    params = params.append('PageSize', 15);
    params = params.append('PageNumber', 1);

    if (sort) {
      if (sort == 'Name') params = params.append('SortBy', 'Name');
      else if (sort == 'PriceAsc' || sort == 'PriceDesc') params = params.append('SortBy', 'Price');
    }

    if (genreName != 'Wszystkie' || !genreName) {
      params = params.append('GenreFiltr', genreName);
    }

    if (sort) {
      if (sort == 'Name' || sort == 'PriceAsc') params = params.append('SortDirection', 'Asc');
      else if (sort == 'PriceDesc') params = params.append('SortDirection', 'Desc');
    }

    return this.http.get<IPagination>(this.baseUrl + 'videogames/search', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      );

  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'videogames/search/product/' + id);
  }

  getGenres() {
    return this.http.get<IGenre[]>(this.baseUrl + 'videogames/search/genres');
  }

  getOpinions(id: number) {
    return this.http.get<IOpinionsAPI>(this.baseUrl + 'videogames/product/' + id + '/opinions', {observe: 'response'})
    .pipe(
      map(response => {
        return response.body;
      })
    )
  }


}
