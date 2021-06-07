import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { IGenre } from 'src/app/shared/models/genres';

@Component({
  selector: 'app-single-genre',
  templateUrl: './single-genre.component.html',
  styleUrls: ['./single-genre.component.scss']
})
export class SingleGenreComponent implements OnInit {
  
  @Input() genre: IGenre;
  genreForm = new FormGroup({
    name: new FormControl('')
  });

  constructor() { }

  @Output() newValueEvent = new EventEmitter<any>();
  ngOnInit(): void {
  }

  onSubmit(oldValue:string, newValue:string) {
    this.updateGenre(oldValue ,newValue);
  }

  updateGenre(oldValue:string,newValue:string){
    this.newValueEvent.emit({newValue, oldValue});
  }

}
