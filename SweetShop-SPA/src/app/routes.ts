import { PhotoListComponent } from './photos/photos-list/photos.component';
import { ShoppingCartComponent } from './shoppingCart/shoppingCart.component';
import { AuthGuard } from './_guards/auth.guard';
import { CategoryEditComponent } from "./categories/categories-edit/category-edit.component";
import { ProductAddComponent } from "./products/product-add/product-add.component";
import { AdminComponent } from "./admin/admin.component";
import { LoginComponent } from "./login/login.component";
import { ProductDetailComponent } from "./products/product-detail/product-detail.component";
import { ProductComponent } from "./products/products.component";
import { HomeComponent } from "./home/home.component";

import { Routes } from "@angular/router";
import { RegisterComponent } from "./register/register.component";

import { ProductEditComponent } from "./products/product-edit/product-edit.component";
import { CategoriesComponent } from "./categories/category.component";
import { CategoryAddComponent } from "./categories/categories-add/categories-add.component";
import { PhotosAddComponent } from './photos/photos-add/photos-add.component';
export const appRoutes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: 'cart',
    component: ShoppingCartComponent
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
    component: AdminComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "admin/product/add",
    component: ProductAddComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "admin/product/edit/:id",
    component: ProductEditComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "categories",
    component: CategoriesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "categories/add",
    component: CategoryAddComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "categories/edit/:id",
    component: CategoryEditComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "photos",
    component: PhotoListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'photos/add',
    component: PhotosAddComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "**",
    redirectTo: "",
    pathMatch: "full"
  }
];
