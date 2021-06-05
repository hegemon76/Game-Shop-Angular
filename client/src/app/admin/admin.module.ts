import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminPanelComponent } from './admin-panel.component';
import { AdminGenreComponent } from './admin-genre/admin-genre.component';
import { AdminProductsComponent } from './admin-products/admin-products.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminUsersComponent } from './admin-users/admin-users.component';



@NgModule({
  declarations: [
    AdminPanelComponent,
    AdminGenreComponent,
    AdminProductsComponent,
    AdminUsersComponent
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
