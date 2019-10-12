import { Photo } from './../../_models/photo';
import { AlertifyService } from "src/app/_services/alertify.service";
import { PhotoService } from "./../../_services/photo.service";
import { OnInit, Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-photo",
  templateUrl: "./photos.component.html",
  styleUrls: ["./photos.component.css"]
})
export class PhotoListComponent implements OnInit {
  photos: any = [];
  imageUrl: string = "";
  fileToUpload: File = null;

  /**
   *
   */
  constructor(
    private photoService: PhotoService,
    private route: ActivatedRoute,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadPhotos();

  }

  loadPhotos() {
    return this.photoService.getPhotos().subscribe((data: {}) => {
      console.log(data);
      this.photos = data;
    });
  }


  delete(id) {
    return this.photoService.delete(id).subscribe(
      data => {
        this.loadPhotos();
      },
      err => {
        this.alertify.error("An error occurs the deleting process!");
      }
    );
  }
}
