import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from "@angular/core";
import { ProductService } from "../_services/cake.service";
import { Product } from '../_models/cake';

@Component({
    selector: 'nav-component',
    templateUrl: './nav.component.html',
    styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{
    
}