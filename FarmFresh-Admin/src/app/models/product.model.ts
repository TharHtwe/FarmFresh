import { Category } from './category.model';
export interface Product {
  id: number;
  name: string;
  categoryId: number;
  description: string;
  images: string;
  countryOfOrigin: string;
  newArrival: boolean;
  onPromotion: boolean;
  category?: Category
}

export interface ProductList {
  products: Product[],
  total: number
}
