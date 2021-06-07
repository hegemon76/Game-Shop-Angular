import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminPanelComponent } from './admin-panel.component';
import { AdminGenreComponent } from './admin-genre/admin-genre.component';
import { AdminProductsComponent } from './admin-products/admin-products.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminClientsComponent } from './admin-clients/admin-clients.component';
import { AddProductComponent } from './admin-products/add-product/add-product.component';
import { AddGenreComponent } from './admin-genre/add-genre/add-genre.component';
import { AddClientComponent } from './admin-clients/add-client/add-client.component';
import { AdminOrdersComponent } from './admin-orders/admin-orders.component';
import { SingleGenreComponent } from './admin-genre/single-genre/single-genre.component';



@NgModule({
  declarations: [
    AdminPanelComponent,
    AdminGenreComponent,
    AdminProductsComponent,
    AdminClientsComponent,
    AddProductComponent,
    AddGenreComponent,
    AddClientComponent,
    AdminOrdersComponent,
    SingleGenreComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],exports:[
    AdminPanelComponent
  ]
})
export class AdminModule { }
