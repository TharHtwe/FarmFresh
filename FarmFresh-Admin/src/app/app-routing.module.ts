import { authGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { EditProductComponent } from './components/products/edit-product/edit-product.component';
import { AddProductComponent } from './components/products/add-product/add-product.component';
import { ProductListComponent } from './components/products/product-list/product-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'products',
    component: ProductListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'products/add',
    component: AddProductComponent,
    canActivate: [authGuard]
  },
  {
    path: 'products/edit/:id',
    component: EditProductComponent,
    canActivate: [authGuard]
  },
  {
    path: '',
    component: HomeComponent,
    canActivate: [authGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
