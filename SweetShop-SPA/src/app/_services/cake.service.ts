import { Cake } from '../_models/cake';
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { retry, catchError, tap } from 'rxjs/operators';
const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };
@Injectable({
    providedIn: 'root'
})
export class CakeService {

    baseUrl = environment.apiUrl;
 

    /**
     *
     */
    constructor(private http: HttpClient) {
    }

    //Add new cake
    getProducts(): Observable<Cake[]> {
        return this.http
            .get<Cake[]>(this.baseUrl + 'cakes');
    }
 
    //Get cake by specified id
    getProduct(id): Observable<Cake> {
        return this.http.get<Cake>(this.baseUrl + 'cakes/' + id);
    }

    //Add new cake
    addProduct(cake): Observable<any> {
        console.log(cake);
        return this.http.post<any>(this.baseUrl + 'cakes', JSON.stringify(cake), httpOptions)
            .pipe(
                tap(_ => console.log(cake+ 'id=${cake.id}')),
                retry(1)
            )
    }

    //Delete cake by id
    deleteProduct(id): Observable<Cake>{
        return this.http.delete<any>(this.baseUrl + 'cakes/' + id);
    }

    //Update cake 
    updateProduct(id, cake): Observable<Cake> {
        return this.http.put<Cake>(this.baseUrl + 'cakes/' + id, JSON.stringify(cake), httpOptions)
                    .pipe(
                        retry(1)
                    )
    } 
    
}