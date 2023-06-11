import { TokenInterceptor } from './interceptors/token.interceptor';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgToastModule } from 'ng-angular-popup';
import { ProductListComponent } from './components/products/product-list/product-list.component';
import { AddProductComponent } from './components/products/add-product/add-product.component';
import { EditProductComponent } from './components/products/edit-product/edit-product.component';
import { HomeComponent } from './components/home/home.component';
import { UploadComponent } from './components/upload/upload.component';
import { HeaderComponent } from './components/header/header.component';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ProductListComponent,
    AddProductComponent,
    EditProductComponent,
    HomeComponent,
    UploadComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    NgToastModule,
    NgxPaginationModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
