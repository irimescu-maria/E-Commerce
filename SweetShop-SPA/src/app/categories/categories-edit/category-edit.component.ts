import { CategoryService } from './../../_services/category.service';
import { OnInit, Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { CakeService } from "src/app/_services/cake.service";
import { AlertifyService } from "src/app/_services/alertify.service";

@Component({
    selector: 'app-category-edit',
    templateUrl: './category-edit.component.html',
    styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {

    category: any;
    id: any;

    /**
     *
     */
    constructor(private router: Router,
                private categoryService: CategoryService,
                private route: ActivatedRoute,
                private alertify: AlertifyService) { }
                
    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.categoryService.getCategory(this.id)
        .subscribe((data: {}) => {
            this.category = data;
            console.log(this.category);
        });
    }

    //Edit cake data
    editCategory() {
        if(window.confirm('Are you sure, you want to update?')) {
            this.categoryService.editCategory(this.id, this.category)
                .subscribe(data => {
                    this.router.navigate(['/categories']),
                    this.alertify.success('Category with id ' + this.category.id +' has been successfully updated');
                })
        }
    }

    cancel() {
        this.router.navigate(['/categories']);
    }
}