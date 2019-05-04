import { AlertifyService } from './../../_services/alertify.service';
import { AuthService } from './../../_services/auth.service';
import { Router } from '@angular/router';
import { Component, Input } from "@angular/core";

@Component({
    selector: 'nav-user-component',
    templateUrl: './nav-user.component.html',
    styleUrls: ['./nav-user.component.css']
})
export class NavUserComponent{
   @Input() userType = 'user';
    model: any = {};

    /**
     *
     */
    constructor(private alertify: AlertifyService,
                public authService: AuthService,
                private router: Router) {
    }

    ngOnInit() {
      console.log(this.authService.currentUser.username);
    }

 // Metoda pentru login
 login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successful');
      console.log(this.model.username);
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