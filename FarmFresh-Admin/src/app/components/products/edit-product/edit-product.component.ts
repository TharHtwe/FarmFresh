import { environment } from './../../../../environments/environment';
import { CategoriesService } from './../../../services/categories.service';
import { ProductsService } from './../../../services/products.service';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/models/category.model';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {
  categories: Category[] = [];
  images: string[] = [];
  selectedCategory: Category={
    id: 0,
    name: ''
  };

  productDetails: Product = {
    id: 0,
    categoryId: 0,
    name: '',
    description: '',
    images: '',
    countryOfOrigin: '',
    newArrival: true,
    onPromotion: true
  }

  response: any;
  imageChanged: boolean = false;

  constructor (private route: ActivatedRoute, private productsService: ProductsService, private categoriesService: CategoriesService, private router: Router) {}

  ngOnInit(): void {
    this.categoriesService.getAllCategories()
      .subscribe({
        next: (categories) => {
          this.categories = categories;
        },
        error: (err) => {
          console.log(err)
        }
      })

    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id) {
          this.productsService.getProduct(parseInt(id))
            .subscribe({
              next: (response) => {
                this.productDetails = response;
                this.images = this.productDetails.images.split(',');
                this.selectedCategory = this.categories.find(c => c.id === this.productDetails.categoryId)!
              },
              error: (err) => {
                console.log(err)
              }
            })
        }
      }
    })
  }

  updateProduct() {
    this.productDetails.categoryId = this.selectedCategory.id
    if(this.imageChanged){
      this.productDetails.images = this.response.list.toString()
    }
    this.productsService.updateProduct(this.productDetails.id, this.productDetails, this.imageChanged)
      .subscribe({
        next: (product) => {
          this.router.navigate(['products']);
        }
      })
  }

  deleteProduct() {
    this.productsService.deleteProduct(this.productDetails.id)
      .subscribe({
        next: (product) => {
          this.router.navigate(['products']);
        }
      })
  }

  uploadFinished(event: any) {
    this.imageChanged = true;
    this.response = event;
  }

  public createImgPath = (serverPath: string) => {
    return `${environment.baseApiUrl}/${serverPath}`;
  }

  trackByFn(index: number, item: any): void {
    return item.id;
  }
}
