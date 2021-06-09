import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.scss']
})
export class SingleProductComponent implements OnInit {
  @Input() product: IProduct;
  @Output() updateEvent = new EventEmitter<any>();
  showProduct: boolean = false;

  productForm = new FormGroup({
    name: new FormControl(''),
    price: new FormControl(0),
    description: new FormControl(''),
    quantity: new FormControl(0),
  });


  constructor() { }

  ngOnInit(): void {
    this.productForm.controls.name.setValue(this.product.name);
    this.productForm.controls.price.setValue(this.product.price);
    this.productForm.controls.description.setValue(this.product.description);
    this.productForm.controls.quantity.setValue(this.product.quantity);
  }

  onSubmit(id: number, name?: string,
    price?: number, description?: string, quantity?: number) {
    const body = {
      'Name': name,
      'Price': price,
      'Description': description,
      'Quantity': quantity
    };
    this.updateEvent.emit({ body, id });
  }



  toggleShowProduct() {
    this.showProduct = !this.showProduct;
  }
}
