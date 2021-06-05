import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http'

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

@NgModule({
  declarations: [
    AppComponent,
    ProductDetailsComponent,
    ProductOpinionsComponent,
    ContactComponent,
    LoginComponent,
    RegisterComponent,
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
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
