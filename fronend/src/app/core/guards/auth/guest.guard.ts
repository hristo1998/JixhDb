import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';


@Injectable()
export class GuestGuard implements CanActivate {
  canActivate(): boolean {
    if (!this.authService.isLoggedIn()) {
      return true;
    } else {
      this.router.navigateByUrl('');
    }
    
    return false;
  }

  constructor(private authService: AuthService, private router: Router) { }
}
