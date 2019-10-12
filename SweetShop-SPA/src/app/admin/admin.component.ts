import { AlertifyService } from './../_services/alertify.service';
import { CakeService } from "./../_services/cake.service";
import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-admin",
  templateUrl: "./admin.component.html",
  styleUrls: ["./admin.component.css"]
})
export class AdminComponent {
  cakes: any = [];

  /**
   *
   */
  constructor(
    private cakeService: CakeService,
    private route: ActivatedRoute,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.cakeService.getProducts().subscribe((data: {}) => {
      console.log(data);
      this.cakes = data;
    });
    console.log(this.cakeService.getProducts());
  }

  add() {
    this.router.navigate(['/admin/product/add']);
  }

  delete(id) {
      this.cakeService.deleteProduct(id)
          .subscribe( data => {
            this.loadProducts();
            this.alertify.success("Successfully deleted");
          }, (err) => {
            this.alertify.error(err);
          }, () => {
            console.log(id);
          });
  }
}
