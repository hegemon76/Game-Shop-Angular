import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './admin/admin-panel.component';
import { BasketComponent } from './basket/basket.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';
import { ClientAccountComponent } from './client-account/client-account.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'sklep', component: ShopComponent },
  { path: 'sklep/:id', component: ProductDetailsComponent },
  { path: 'koszyk', component: BasketComponent },
  {path: 'admin-panel', component: AdminPanelComponent},
  {path: 'kontakt', component: ContactComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'moje-konto', component: ClientAccountComponent},
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
