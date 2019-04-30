import { ProductAddComponent } from "./products/product-add/product-add.component";
import { AdminComponent } from "./admin/admin.component";
import { LoginComponent } from "./login/login.component";
import { ProductDetailComponent } from "./products/product-detail/product-detail.component";
import { ProductComponent } from "./products/products.component";
import { HomeComponent } from "./home/home.component";

import { Routes } from "@angular/router";
import { RegisterComponent } from "./register/register.component";
import { patch } from "webdriver-js-extender";
import { ProductEditComponent } from "./products/product-edit/product-edit.component";
export const appRoutes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "products",
    component: ProductComponent
  },
  {
    path: "products/:id",
    component: ProductDetailComponent
  },
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "admin",
    component: AdminComponent
  },
  {
    path: "admin/product/add",
    component: ProductAddComponent
  },
  {
    path: "admin/product/edit/:id",
    component: ProductEditComponent
  },
  {
    path: "**",
    redirectTo: "",
    pathMatch: "full"
  }
];
