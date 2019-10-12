import { AlertifyService } from "src/app/_services/alertify.service";
import { AuthService } from "./../_services/auth.service";
import { CanActivate, Router } from "@angular/router";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class AuthGuard implements CanActivate {
  /**
   *
   */
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  canActivate(): boolean {
    if (this.authService.loggedIn() && this.authService.currentUser.username == 'admin') {
      return true;
    }

    this.alertify.error("You shall not pass!");
    this.router.navigate(["/"]);
    return false;
  }
}
