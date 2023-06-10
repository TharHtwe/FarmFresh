import { ProductsService } from './../../../services/products.service';
import { Product } from './../../../models/product.model';
import { CategoriesService } from './../../../services/categories.service';
import { Category } from './../../../models/category.model';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
  categories: Category[] = [];
  selectedCategory: Category={
    id: 0,
    name: ''
  };

  addProductRequest: Product = {
    id: 0,
    categoryId: 0,
    name: '',
    description: ''
  }

  constructor(private categoriesService: CategoriesService, private productsService: ProductsService, private router: Router) {}

  ngOnInit(): void {
    this.categoriesService.getAllCategories()
      .subscribe({
        next: (categories) => {
          this.categories = categories
        },
        error: (err) => {
          console.log(err)
        }
      })
  }

  addProduct() {
    this.addProductRequest.categoryId = this.selectedCategory.id
    this.productsService.addProduct(this.addProductRequest)
      .subscribe({
        next: (product) => {
          this.router.navigate(['products'])
        }
      })
  }

  trackByFn(index: number, item: any): void {
    return item.id;
  }
}
