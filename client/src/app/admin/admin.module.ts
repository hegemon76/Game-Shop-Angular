import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminPanelComponent } from './admin-panel.component';
import { AdminGenreComponent } from './admin-genre/admin-genre.component';
import { AdminProductsComponent } from './admin-products/admin-products.component';



@NgModule({
  declarations: [
    AdminPanelComponent,
    AdminGenreComponent,
    AdminProductsComponent
  ],
  imports: [
    CommonModule
  ],exports:[
    AdminPanelComponent
  ]
})
export class AdminModule { }
