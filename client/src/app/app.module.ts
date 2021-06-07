import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http'
import {FormsModule, ReactiveFormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { ShopModule } from './shop/shop.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { HomeModule } from './home/home.module';
import { AdminModule } from './admin/admin.module';
import { ProductOpinionsComponent } from './product-details/product-opinions/product-opinions.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ClientAccountComponent } from './client-account/client-account.component';
import { ClientDataComponent } from './client-account/client-data/client-data.component';
import { ClientOrdersComponent } from './client-account/client-orders/client-orders.component';
import { ClientOpinionsComponent } from './client-account/client-opinions/client-opinions.component';


@NgModule({
  declarations: [
    AppComponent,
    ProductDetailsComponent,
    ProductOpinionsComponent,
    ContactComponent,
    LoginComponent,
    RegisterComponent,
    ClientAccountComponent,
    ClientDataComponent,
    ClientOrdersComponent,
    ClientOpinionsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    ShopModule,
    HomeModule,
    AdminModule,
    BsDropdownModule.forRoot(),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
