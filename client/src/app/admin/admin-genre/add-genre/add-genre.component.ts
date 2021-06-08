import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IGenre } from 'src/app/shared/models/genres';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-genre',
  templateUrl: './add-genre.component.html',
  styleUrls: ['./add-genre.component.scss']
})
export class AddGenreComponent implements OnInit {
  @Output() newGenreEvent = new EventEmitter<IGenre>();

  constructor() { }

  genreForm = new FormGroup({
    name: new FormControl('')
  });

  ngOnInit(): void {
  }

  onSubmit(newGenre: any) {
    if (newGenre) {
      this.newGenreEvent.emit(newGenre);
    }
  }

}
