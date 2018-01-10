import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { TokenService } from '../../services/auth/token.service';
import { StorageService } from '../../services/auth/storage.service';
import { Configs } from '../../shared/configs';

@Injectable()
export class ModeratorGuard implements CanActivate {
  canActivate(): boolean {
    if (this.authService.isInRole(Configs.moderatorRoleName)) {
      return true;
    } else {
      this.router.navigateByUrl('login');
    }
    
    return false;
  }

  constructor(
        private authService: AuthService,
        private router: Router       
    ) { }
}
