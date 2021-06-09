import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { IGenre } from 'src/app/shared/models/genres';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.scss']
})
export class SingleProductComponent implements OnInit {
  @Input() product: IProduct;
  @Input() genres: IGenre[];
  @Output() updateEvent = new EventEmitter<any>();
  showProduct: boolean = false;
  selected: any;

  productForm = new FormGroup({
    name: new FormControl(''),
    price: new FormControl(0),
    description: new FormControl(''),
    quantity: new FormControl(0),
    genre: new FormControl('')
  });


  constructor() { }

  ngOnInit(): void {
    this.setDefaults();
  }

  onSubmit(id: number, name?: string,
    price?: number, description?: string, quantity?: number, genre?: any) {
    const body = {
      'Name': name,
      'Price': price,
      'Description': description,
      'Quantity': quantity,
      'Genre': genre
    };

    this.updateEvent.emit({ body, id });
  }

  setDefaults() {
    this.productForm.controls.name.setValue(this.product.name);
    this.productForm.controls.price.setValue(this.product.price);
    this.productForm.controls.description.setValue(this.product.description);
    this.productForm.controls.quantity.setValue(this.product.quantity);
    this.productForm.controls.genre.setValue(this.product.genre);
  }

  toggleShowProduct() {
    this.showProduct = !this.showProduct;
  }
}
