import { Router, ActivatedRoute } from "@angular/router";
import { PhotoService } from "./../../_services/photo.service";
import { OnInit, Component, ViewChild } from "@angular/core";

@Component({
  selector: "app-photos-add",
  templateUrl: "./photos-add.component.html",
  styleUrls: ["./photos-add.component.css"]
})
export class PhotosAddComponent {
  fileToUpload: File = null;
  imageUrl: string = "";
  @ViewChild("fileInput") fileInput: any;
  /**
   *
   */
  constructor(
    private photoService: PhotoService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  onFileSelected(event) {
    this.fileToUpload = event.target.files[0];
    console.log(this.fileToUpload);
  }

  onUpload(filesData) {
    // let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    // this.photoService.addPhoto(nativeElement.files);
    // console.log(nativeElement.files);

    this.photoService.addPhoto(this.fileToUpload).subscribe(data => {
      console.log(this.fileToUpload);
      filesData.value = null;
      this.photoService.getPhotos();
      this.imageUrl = null;
    });
  }
  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    //Show image preview
    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };
    reader.readAsDataURL(this.fileToUpload);
  }

  // this.router.navigate(['/photos']);
  // const fd = new FormData();
  // fd.append('image', this.selectedFile, this.selectedFile.name);
  // this.photoService.addPhoto(fd)
  //     .subscribe( res => {
  //         console.log(res);
  //     });
}
