import { OnInit, Component, Input } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { CategoryService } from "src/app/_services/category.service";
import { Router } from "@angular/router";
import { AlertifyService } from "src/app/_services/alertify.service";

@Component({
    selector: 'app-category-add',
    templateUrl: './categories-add.component.html',
    styleUrls: ['./categories-add.component.css']
})
export class CategoryAddComponent implements OnInit {
    @Input() category = {
        name: ''
    };

    addForm: FormGroup;
    /**
     *
     */
    constructor(private categoryService: CategoryService,
                private router: Router,
                private fb: FormBuilder,
                private alertify: AlertifyService ) {

    }

    ngOnInit() {
        this.createAddForm();
    }

    add() {
        this.categoryService.addCategory(this.category)
            .subscribe((data: {}) => {
                this.router.navigate(['/categories'])
            }, (error) => {
               this.alertify.error(error);
            });
        }

    createAddForm() {
        this.addForm = this.fb.group({
          name: ['', Validators.required]
                });
      }
      cancel(){
          this.router.navigate(['/categories']);
      }
}