import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Category } from '../_models/category';
import { Observable } from 'rxjs';
import { retry } from 'rxjs/operators';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

@Injectable({
    providedIn: 'root'
})
export class CategoryService {

    baseUrl = environment.apiUrl;

    /**
     *
     */
    constructor(private http: HttpClient) {}

    //Get list of categories
    getCategories(): Observable<Category[]> {
        return this.http.get<Category[]>(this.baseUrl + 'categories');
    }

    getCategory(id): Observable<Category> {
        return this.http.get<Category>(this.baseUrl + 'categories/'+ id);
    }

    //Add category
    addCategory(category): Observable<Category> {
        return this.http.post<Category>(this.baseUrl + 'categories', JSON.stringify(category), httpOptions)
                .pipe(
                    retry(1)
                )
    }

    //Delete category
    deleteCategory(id): Observable<Category> {
        return this.http.delete<any>(this.baseUrl + 'categories/' + id);
    }

    editCategory(id, category): Observable<Category> {
        return this.http.put<Category>(this.baseUrl + 'categories/'+ id, JSON.stringify(category), httpOptions)
            .pipe(
                retry(1)
            )
    }
}