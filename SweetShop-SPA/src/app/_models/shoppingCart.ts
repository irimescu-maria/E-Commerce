import { Cake } from "./cake";

export interface ShoppingCart {
    shoppingCartItemId: number;
    shoppingCartId: number;
    amount:  number;
    cake: Cake[];
}