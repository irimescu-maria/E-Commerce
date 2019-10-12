import { AlertifyService } from './../_services/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from "@angular/core";
import { ShoppingCart } from "../_models/shoppingCart";
import { ShoppingCartService } from "../_services/shoppingCart.service";

@Component({
    selector: 'app-shoppingCart',
    templateUrl: './shoppingCart.component.html',
    styleUrls: ['./shoppingCart.component.css']
})
export class ShoppingCartComponent implements OnInit{
    
    shoppingCartItems: any = [];

    /**
     *
     */
    constructor(private shoppingCartService: ShoppingCartService,
                private route: ActivatedRoute,
                private router: Router,
                private alertify:AlertifyService ) {}

    ngOnInit() {
        this.loadCartItems();
    }

    loadCartItems() {
        this.shoppingCartService.getShoppingCartList()
            .subscribe(
                (data: {}) => {
                    console.log(data);
                    this.shoppingCartItems = data;
                }
            );
            console.log(this.shoppingCartService.getShoppingCartList());
    }

    delete(id) {
        this.shoppingCartService.deleteItemFromCart(id)
            .subscribe(data => {
                this.loadCartItems();
                this.alertify.success("Successfully deleted");
            }, (error) => {
                this.alertify.error(error);
            });
    }

    cancel() {
        return this.router.navigate(['/products']);
    }
}