import { Router } from '@angular/router';
import { AuthService } from './../_services/auth.service';
import { AlertifyService } from './../_services/alertify.service';
import { Component, Input } from "@angular/core";

@Component({
    selector: 'nav-component',
    templateUrl: './nav.component.html',
    styleUrls: ['./nav.component.css']
})
export class NavComponent{
   
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
      this.router.navigate(['/products']); // Redirect to members page after login
    });
  }

 loggedIn() {
   return this.authService.loggedIn();
 }

 logout() {
   localStorage.removeItem('token');
   localStorage.removeItem('user');
   this.authService.decodedToken = null;
   this.authService.currentUser = null;
   this.alertify.message('Logged out');
   this.router.navigate(['/']); // Redirect to home page after logout
 }
}