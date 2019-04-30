import { ActivatedRoute, Router } from '@angular/router';
import { CakeService } from './../../_services/cake.service';
import { Component, OnInit, Input, ViewChildren } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
    selector:'app-product-add',
    templateUrl: './product-add.component.html',
    styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit{

    @Input() cake = {
        name: '',
        description: '',
        photo: '',
        price: 0,
        quantity: 0,
        status: false,
        categoryId: 0
    };
    addForm: FormGroup;
    /**
     *
     */
    constructor(private cakeService: CakeService,
                private router: Router,
                private fb: FormBuilder,
                private alertify: AlertifyService ) {

    }

    ngOnInit() {
        this.createAddForm();
    }

    add() {
        this.cakeService.addProduct(this.cake)
            .subscribe((data: {}) => {
                this.router.navigate(['/admin'])
            }, (error) => {
               this.alertify.error(error);
            });
        }

    createAddForm() {
        this.addForm = this.fb.group({
          name: ['', Validators.required],
          description: ['', Validators.required],
          photo: ['', Validators.required],
          price: ['', Validators.required],
          quantity: ['', Validators.required],
          status: ['', Validators.required],
          categoryId: ['', Validators.required]
        });
      }
}