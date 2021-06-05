import { Component, Input, OnInit } from '@angular/core';
import { IGenre } from 'src/app/shared/models/genres';

@Component({
  selector: 'app-admin-genre',
  templateUrl: './admin-genre.component.html',
  styleUrls: ['./admin-genre.component.scss']
})
export class AdminGenreComponent implements OnInit {
  @Input() genres: IGenre[];

  constructor() { }

  ngOnInit(): void {
  }

}
