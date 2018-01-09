import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UserService } from '../services/users/user.service';

@Injectable()
export class GuestGuard implements CanActivate {
  canActivate(): boolean {
    if (this.user.checkLoggedIn()) {
      return true;
    } else {
      this.router.navigateByUrl('teams');
    }
    
    return false;
  }

  constructor(private user: UserService, private router: Router) { }
}
