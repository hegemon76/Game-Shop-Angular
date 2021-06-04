import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IGenre } from '../shared/models/genres';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<IPagination>(this.baseUrl + 'videogames/search/?PageSize=15&PageNumber=1')
  }

  getGenres(){
    return this.http.get<IGenre[]>(this.baseUrl + 'videogames/search/genres');
  }
}
