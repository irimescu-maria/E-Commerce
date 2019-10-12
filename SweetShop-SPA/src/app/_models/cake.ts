import { Category } from './category';
export interface Cake {
    id: number;
    name: string;
    description: string;
    photo: string;
    price: number;
    quantity: number;
    status: boolean;    
    categoryId: number;
    photoId: number;
}