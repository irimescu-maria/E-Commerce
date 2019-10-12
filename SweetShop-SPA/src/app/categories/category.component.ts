import { AlertifyService } from './../_services/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from './../_services/category.service';
import { Component, OnInit } from "@angular/core";

@Component({
    selector: 'app-categories',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css']
})
export class CategoriesComponent implements OnInit{

    categories: any = [];
    /**
     *
     */
    constructor(private categoriesService: CategoryService,
                private route: ActivatedRoute,
                private router: Router,
                private alertify: AlertifyService) { }


    ngOnInit() {
        this.loadCategories();
    }

    loadCategories() {
        return this.categoriesService.getCategories()
        .subscribe((data: {}) => {
            console.log(data);
            this.categories = data;
        });
    }

    delete(id) {
       this.categoriesService.deleteCategory(id)
                    .subscribe(data => {
                        this.loadCategories();
                        this.alertify.success("Successfully deleted");
                    }, (err) => {
                        this.alertify.error("An error occurs the deleting process!");
                    });

    }

}