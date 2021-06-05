import { Component, Input, OnInit } from '@angular/core';
import { IOpinion } from 'src/app/shared/models/opinion';

@Component({
  selector: 'app-product-opinions',
  templateUrl: './product-opinions.component.html',
  styleUrls: ['./product-opinions.component.scss']
})
export class ProductOpinionsComponent implements OnInit {
  @Input() opinion: IOpinion;
  
  constructor() { }

  ngOnInit(): void {
  }

}
