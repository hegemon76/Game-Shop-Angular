import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { IGenre } from 'src/app/shared/models/genres';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {
  @Input() genres: IGenre[];
  @Output() newProduct = new EventEmitter<any>();

  newProductForm = new FormGroup({
    name: new FormControl(''),
    price: new FormControl(0),
    description: new FormControl(''),
    quantity: new FormControl(0),
    genreId: new FormControl(''),
  });

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(name: string,
    price: number, description: string, quantity: number, genreId: any, pictureUrl?: string) {
    const body = {
      'Name': name,
      'Price': price,
      'Description': description,
      'Quantity': quantity,
      'GenreId': genreId
    };
    this.newProduct.emit(body);
  }
} //app
