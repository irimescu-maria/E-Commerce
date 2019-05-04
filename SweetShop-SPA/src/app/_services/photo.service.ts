import { tap, map } from 'rxjs/operators';
import { Photo } from './../_models/photo';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Observable } from 'rxjs';


const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'multipart/form-data'
    })
  };

@Injectable({
    providedIn: 'root'
})
export class PhotoService {

    baseUrl = environment.apiUrl;

    /**
     *
     */
    constructor(private http: HttpClient) {}

    //Get list of photos
    getPhotos(): Observable<Photo[]> {
        return this.http.get<Photo[]>(this.baseUrl + 'photo');
    }

    //Add photo
    addPhoto(file: File) {
        const input: FormData = new FormData();
        input.append('filesData', file, file.name);
        console.log(file);
        return this.http.post(this.baseUrl + 'photo', input);
    }

    delete(id): Observable<Photo>{
        return this.http.delete<any>(this.baseUrl + 'photo/'+ id);
    }
}