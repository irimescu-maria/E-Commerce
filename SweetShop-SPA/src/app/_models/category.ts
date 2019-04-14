import { Cake } from './cake';
export interface Category{
    id: number;
    name: string;
    products?: Cake[]
}