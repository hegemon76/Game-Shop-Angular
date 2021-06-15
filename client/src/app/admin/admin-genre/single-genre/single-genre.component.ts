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

  @Output() updateGenreEvent = new EventEmitter<any>();
  @Output() deleteGenreEvent = new EventEmitter<any>();
  ngOnInit(): void {
  }

  onSubmit(id:number, newValue:string) {
    this.updateGenre(id ,newValue);
  }

  updateGenre(id:number,newValue:string){
    this.updateGenreEvent.emit({newValue, id});
  }

  deleteGenre(genreId: any){
    console.log(genreId);
    this.deleteGenreEvent.emit(genreId);
  }

}
