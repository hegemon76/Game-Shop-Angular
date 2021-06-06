import { Component, Input, OnInit } from '@angular/core';
import { IGenre } from 'src/app/shared/models/genres';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ShopService } from 'src/app/shop/shop.service';

@Component({
  selector: 'app-admin-genre',
  templateUrl: './admin-genre.component.html',
  styleUrls: ['./admin-genre.component.scss']
})
export class AdminGenreComponent implements OnInit {
  @Input() genres: IGenre[];
  newName: any;
  oldName: any;
  isAddGenre: boolean = false;

  // genreForm = this.formBuilder.group({
  //   name: '',
  //   oldName: ''
  // });
  genreForm = new FormGroup({
    name: new FormControl('')
  });

  constructor(private formBuilder: FormBuilder, private shopService: ShopService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    //this.newName = this.genreForm.value.name;
    console.log(this.genreForm);
  }

  toggleAddGenre() {
    this.isAddGenre = !this.isAddGenre;
  }

}
