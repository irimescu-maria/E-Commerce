import { Cake } from './../_models/cake';
import { CakeService } from '../_services/cake.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
    selector: 'app-product',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.css']
})
export class ProductComponent implements OnInit{

    cakes: any = [];

    /**
     *
     */
    constructor(private cakeService: CakeService,
                private route: ActivatedRoute) {
        
    }

    ngOnInit() {
       this.loadProducts();
    }

    loadProducts() {
        this.cakeService
            .getProducts()
            .subscribe(
                (data: {}) => {
                    console.log(data);
                    this.cakes = data;
                }
            );
            console.log(this.cakeService.getProducts());
    }


}