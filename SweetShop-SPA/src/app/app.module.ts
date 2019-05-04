import { PhotoService } from './_services/photo.service';
import { AuthGuard } from './_guards/auth.guard';
import { CategoryAddComponent } from './categories/categories-add/categories-add.component';
import { CategoryEditComponent } from './categories/categories-edit/category-edit.component';
import { CategoryService } from './_services/category.service';
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { ProductAddComponent } from './products/product-add/product-add.component';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';
import { AlertifyService } from './_services/alertify.service';
import { AuthService } from './_services/auth.service';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';

import { CakeService } from './_services/cake.service';
import { ProductComponent } from './products/products.component';
import { HomeComponent } from './home/home.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BsDropdownModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { CategoriesComponent } from './categories/category.component';
import { JwtModule } from '@auth0/angular-jwt';
import { ShoppingCartComponent } from './shoppingCart/shoppingCart.component';
import { NavUserComponent } from './nav/nav-user/nav-user.component';
import { NavAdminComponent } from './nav/nav-admin/nav-admin.component';
import { PhotoListComponent } from './photos/photos-list/photos.component';
import { PhotosAddComponent } from './photos/photos-add/photos-add.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    NavUserComponent,
    NavAdminComponent,
    HomeComponent,
    ProductComponent,
    ProductDetailComponent,
    RegisterComponent,
    LoginComponent,
    AdminComponent,
    ProductAddComponent,
    ProductEditComponent,
    CategoriesComponent,
    CategoryEditComponent,
    CategoryAddComponent,
    ShoppingCartComponent,
    PhotoListComponent,
    PhotosAddComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    BsDropdownModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5001'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      }
    })

  ],
  providers: [
    CakeService,
    AuthService,
    AlertifyService,
    CategoryService,
    PhotoService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
