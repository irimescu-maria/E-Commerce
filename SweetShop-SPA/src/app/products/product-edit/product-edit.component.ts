import { AlertifyService } from 'src/app/_services/alertify.service';
import { CakeService } from './../../_services/cake.service';
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: 'app-product-edit',
    templateUrl: './product-edit.component.html',
    styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit{

    cake: any;
    id: any;

    /**
     *
     */
    constructor(private router: Router,
                private cakeService: CakeService,
                private route: ActivatedRoute,
                private alertify: AlertifyService) { }
                
    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.cakeService.getProduct(this.id)
        .subscribe((data: {}) => {
            this.cake = data;
            console.log(this.cake);
        });
    }

    //Edit cake data
    updateCake() {
        if(window.confirm('Are you sure, you want to update?')) {
            this.cakeService.updateProduct(this.id, this.cake)
                .subscribe(data => {
                    this.router.navigate(['/admin']),
                    this.alertify.success(this.cake.name +' successfully updated');
                })
        }
    }
}