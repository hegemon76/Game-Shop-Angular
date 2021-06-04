import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-opinions',
  templateUrl: './product-opinions.component.html',
  styleUrls: ['./product-opinions.component.scss']
})
export class ProductOpinionsComponent implements OnInit {
  @Input() opinion: any;
  constructor() { }

  ngOnInit(): void {
  }

}
