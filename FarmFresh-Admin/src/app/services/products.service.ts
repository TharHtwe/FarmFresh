import { Product, ProductList } from './../models/product.model';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllProducts(page: number, perPage: number, search: string, orderBy: string, direction: string): Observable<ProductList> {
    return this.http.get<ProductList>(this.baseApiUrl + '/api/products?' + `page=${page}&perPage=${perPage}&orderBy=${orderBy}&direction=${direction}&search=${search}`);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(this.baseApiUrl + '/api/products/' + id);
  }

  addProduct(addProductRequest: Product): Observable<Product> {
    return this.http.post<Product>(this.baseApiUrl + '/api/products', addProductRequest);
  }

  updateProduct(id: number, updateProductRequest: Product, imageChanged: boolean): Observable<Product> {
    return this.http.put<Product>(`${this.baseApiUrl}/api/products/${id}?imageChanged=${imageChanged}`, updateProductRequest);
  }

  deleteProduct(id: number): Observable<Product> {
    return this.http.delete<Product>(this.baseApiUrl + '/api/products/' + id);
  }
}
