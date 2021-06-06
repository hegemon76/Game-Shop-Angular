import { Component, OnInit, Input } from '@angular/core';
import { IUsers } from 'src/app/shared/models/user';

@Component({
  selector: 'app-admin-clients',
  templateUrl: './admin-clients.component.html',
  styleUrls: ['./admin-clients.component.scss']
})
export class AdminClientsComponent implements OnInit {
  @Input() users: IUsers[];
  showClientsInfo: number;
  isAddClient: boolean = false;
  constructor() { }

  ngOnInit(): void {
  }

  showClient(id: number) {
    this.showClientsInfo = id;
  }

  closeClientInfo() {
    this.showClientsInfo = null;
  }

  toggleAddClient() {
    this.isAddClient = !this.isAddClient;
  }

}