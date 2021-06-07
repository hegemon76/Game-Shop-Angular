import { Component, Input, OnInit } from '@angular/core';
import { IClient } from 'src/app/shared/models/client';

@Component({
  selector: 'app-client-data',
  templateUrl: './client-data.component.html',
  styleUrls: ['./client-data.component.scss']
})
export class ClientDataComponent implements OnInit {
  @Input() client: IClient;
  constructor() { }

  ngOnInit(): void {
  }

}