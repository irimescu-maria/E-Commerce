import { ProductComponent } from './products/products.component';
import { HomeComponent } from './home/home.component';

import { Routes } from "@angular/router";
export const appRoutes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'products',
        component: ProductComponent
    },
    {
        path: '**',
        redirectTo: '',
        pathMatch: 'full'
    }
];