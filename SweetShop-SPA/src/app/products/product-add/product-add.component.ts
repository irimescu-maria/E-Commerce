import { PhotoService } from "./../../_services/photo.service";
import { Photo } from "./../../_models/photo";
import { CategoryService } from "./../../_services/category.service";
import { Category } from "./../../_models/category";
import { Router } from "@angular/router";
import { CakeService } from "./../../_services/cake.service";
import { Component, OnInit, Input } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AlertifyService } from "src/app/_services/alertify.service";

@Component({
  selector: "app-product-add",
  templateUrl: "./product-add.component.html",
  styleUrls: ["./product-add.component.css"]
})
export class ProductAddComponent implements OnInit {
  @Input() cake = {
    name: "",
    description: "",
    photo: "",
    price: 0,
    quantity: 0,
    status: false,
    categoryId: 0,
    photoId: 0
  };

  categories: Category[];
  selectedCategory: number;
  addForm: FormGroup;

  photos: Photo[];
  /**
   *
   */
  constructor(
    private cakeService: CakeService,
    public categoryService: CategoryService,
    private router: Router,
    private fb: FormBuilder,
    private alertify: AlertifyService,
    private photoService: PhotoService
  ) {
  }

  ngOnInit() {
    this.createAddForm();
    this.loadPhotos();
    this.loadCategories();
    // this.categoryService.getCategories()
    // .subscribe((data => this.categories = data)
    // );
    // console.log(this.categories);
  }

  add() {
    this.cakeService.addProduct(this.cake).subscribe(
      () => {
        this.router.navigate(["/admin"]);
      },
      error => {
        this.alertify.error("An eeror occurs when adding the data");
        console.log(error);
      }
    );
  }

  createAddForm() {
    this.addForm = this.fb.group({
      name: ["", Validators.required],
      description: ["", Validators.required],
      // photo: ["", Validators.required],
      price: ["", Validators.required],
      quantity: ["", Validators.required],
      status: ["", Validators.required],
      categoryId: ["", Validators.required],
      photoId: ["", Validators.required]
    });
  }

  loadPhotos() {
    this.photoService.getPhotos().subscribe(data => {
      console.log(data);
      this.photos = data;
    });
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe(data => {
      this.categories = data;
    });
  }

  cancel() {
    this.router.navigate(["/admin"]);
  }
}
