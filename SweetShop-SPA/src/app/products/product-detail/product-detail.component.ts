import { AlertifyService } from 'src/app/_services/alertify.service';
import { Cake } from './../../_models/cake';
import { ActivatedRoute } from '@angular/router';
import { CakeService } from './../../_services/cake.service';
import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from 'src/app/_services/shoppingCart.service';

@Component({
    selector: "app-product-detail",
    templateUrl: "./product-detail.component.html",
    styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit{
  
    cake: any;
    id: any;
    /**
     *
     */
    constructor(private cakeService: CakeService,
                private shoppingCartService: ShoppingCartService,
                private alertify: AlertifyService,
                private route: ActivatedRoute) {
        
    }

    ngOnInit(): void {
        
        this.id = this.route.snapshot.params['id'];
        this.cakeService
            .getProduct(this.id)
            .subscribe(
                (data: {}) => {
                    this.cake = data;
                }
            );
    }

    addToCart() {
        this.shoppingCartService.addToCart(this.id)
            .subscribe((data: {}) => {
                this.alertify.message("${cake.id} has been added to cart")
            }, (error) => {
                this.alertify.error(error);
            });
    }
}