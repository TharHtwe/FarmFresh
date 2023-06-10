import { Product } from './../models/product.model';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseApiUrl + '/api/products');
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(this.baseApiUrl + '/api/products/' + id);
  }

  addProduct(addProductRequest: Product): Observable<Product> {
    return this.http.post<Product>(this.baseApiUrl + '/api/products', addProductRequest);
  }

  updateProduct(id: number, updateProductRequest: Product): Observable<Product> {
    return this.http.put<Product>(this.baseApiUrl + '/api/products/' + id, updateProductRequest);
  }

  deleteProduct(id: number): Observable<Product> {
    return this.http.delete<Product>(this.baseApiUrl + '/api/products/' + id);
  }
}
