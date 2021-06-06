import { Component, Input, OnInit } from '@angular/core';
import { IUsers } from 'src/app/shared/models/user';

@Component({
  selector: 'app-client-data',
  templateUrl: './client-data.component.html',
  styleUrls: ['./client-data.component.scss']
})
export class ClientDataComponent implements OnInit {
  @Input() users: IUsers[];
  showMyDataInfo: number;
  constructor() { }

  ngOnInit(): void {
  }

}