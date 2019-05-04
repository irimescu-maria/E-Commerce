import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { ShoppingCart } from '../_models/shoppingCart';
import { Observable } from 'rxjs';
import { Cake } from '../_models/cake';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

@Injectable({
    providedIn: 'root'
})
export class ShoppingCartService {

    baseUrl = environment.apiUrl;

    /**
     *
     */
    constructor(private http: HttpClient) {}

    //Get items from shopping cart
    getShoppingCartList(): Observable<ShoppingCart[]> {
        return this.http.get<ShoppingCart[]>(this.baseUrl + 'shoppingCart');
    }

    addToCart(id): Observable<Cake> {
        return this.http.post<any>(this.baseUrl + 'shoppingCart/' + id,
        httpOptions);
    }

    deleteItemFromCart(id): Observable<ShoppingCart> {
        return this.http.delete<any>(this.baseUrl + 'shoppingCart/' + id);
    }
}