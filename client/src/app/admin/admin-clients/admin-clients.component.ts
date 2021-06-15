import { Component, OnInit, Input } from '@angular/core';
import { IClient } from 'src/app/shared/models/client';
import { ShopService } from 'src/app/_services/shop.service';

@Component({
  selector: 'app-admin-clients',
  templateUrl: './admin-clients.component.html',
  styleUrls: ['./admin-clients.component.scss']
})
export class AdminClientsComponent implements OnInit {
  @Input() clients: IClient[];
  isAddClient: boolean = false;
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getClients();
  }

  toggleAddClient() {
    this.isAddClient = !this.isAddClient;
  }
  
  addClient(event: any) {
    this.shopService.addClient(event).subscribe( (response: any )=> {
        console.log(response);
        this.toggleAddClient();
    }, error => {
      console.log(error);
    });
  }

  updateClient(event:any) {
    this.shopService.updateClient(event.id, event.body).subscribe((response: any )=> {
      console.log(response);
      this.ngOnInit();
  }, error => {
    console.log(error);
  });
  }

  getClients() {
    this.shopService.getClients().subscribe(response => {
      this.clients = response;
    }, error => {
      console.log(error);
    });
  }

}