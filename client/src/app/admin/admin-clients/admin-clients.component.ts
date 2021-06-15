import { Component, OnInit, Input } from '@angular/core';
import { IClient } from 'src/app/shared/models/client';
import { IRoles } from 'src/app/shared/models/role';
import { ShopService } from 'src/app/_services/shop.service';

@Component({
  selector: 'app-admin-clients',
  templateUrl: './admin-clients.component.html',
  styleUrls: ['./admin-clients.component.scss']
})
export class AdminClientsComponent implements OnInit {
  clients: IClient[];
  roles: IRoles[];
  isAddClient: boolean = false;
  
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getClients();
  }


  //#region CLIENT section

  toggleAddClient() {
    this.isAddClient = !this.isAddClient;
  }

  addClient(event: any) {
    this.shopService.addClient(event).subscribe((response: any) => {
      this.toggleAddClient();
    }, error => {
      console.log(error);
    });
  }

  updateClient(event: any) {
    console.log(event.userId);
    this.shopService.updateClient(event.userId, event.body).subscribe((response: any) => {
      if (response) {
        this.ngOnInit();
      }
    }, error => {
      console.log(error);
    });
  }

  getClients() {
    this.shopService.getClients().subscribe(response => {
      if (response) {
        this.clients = response;
      }

    }, error => {
      console.log(error);
    });
  }

  //#endregion
}