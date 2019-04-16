import { Cake } from './../../_models/cake';
import { ActivatedRoute } from '@angular/router';
import { CakeService } from './../../_services/cake.service';
import { Component, OnInit } from '@angular/core';

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
}