import { Router } from '@angular/router';
import { ProductsService } from './../../../services/products.service';
import { Product } from './../../../models/product.model';
import { Component } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  products: Product[] = [];
  total: number = 0;
  perPage: number = 3;
  page: number = 1;
  search: string = '';
  orderBy: string = 'name';
  direction: string = 'asc';

  constructor(private productsService: ProductsService, private router: Router) {}

  ngOnInit(): void {
    this.fetchProducts()
  }

  fetchProducts() {
    this.productsService.getAllProducts(this.page, this.perPage, this.search, this.orderBy, this.direction)
    .subscribe({
      next: (response) => {
        this.products = response.products
        this.total = response.total
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  deleteProduct(id: number) {
    this.productsService.deleteProduct(id)
      .subscribe({
        next: (product) => {
          let index = this.products.findIndex(d => d.id === id);
          this.products.splice(index, 1);
        }
      })
  }

  addProduct() {
    this.router.navigate(['/products/add'])
  }

  renderPage(event: number) {
    this.page = event;
    this.fetchProducts();
  }

  trackByFn(index: number, item: any): void {
    return item.id;
  }
}
