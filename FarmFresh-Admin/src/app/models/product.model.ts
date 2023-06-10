import { Category } from './category.model';
export interface Product {
  id: number;
  name: string;
  categoryId: number;
  description: string;
  category?: Category
}
