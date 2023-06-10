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

  constructor(private productsService: ProductsService) {}

  ngOnInit(): void {
    this.productsService.getAllProducts()
    .subscribe({
      next: (products) => {
        this.products = products
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  deleteProduct(id: number) {
    // this.productsService.deleteProduct(id)
    //   .subscribe({
    //     next: (product) => {
    //       this.router.navigate(['products']);
    //     }
    //   })
    let index = this.products.findIndex(d => d.id === id);
    this.products.splice(index, 1);
  }

  trackByFn(index: number, item: any): void {
    return item.id;
  }
}
