import { AuthService } from './../_services/auth.service';
import { AlertifyService } from './../_services/alertify.service';
import { Component, OnInit } from "@angular/core";
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

    model: any = {};

    /**
     *
     */
    constructor(private alertify: AlertifyService,
                public authService: AuthService,
                private router: Router) {
    }

    ngOnInit(): void {
    }

 // Metoda pentru login
 login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successful');
    }, error => {
     this.alertify.error('Failed to login');
    }, () => {
      if(this.authService.currentUser.username == 'admin') {
        this.router.navigate(['/admin']);
      }else{
      this.router.navigate(['/products']); // Redirect to members page after login
      }
    });
  }

 loggedIn() {
   return this.authService.loggedIn();
 }
}