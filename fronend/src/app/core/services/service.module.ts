import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthService } from './auth/auth.service';
import { HttpService } from './auth/http.service';
import { StorageService } from './auth/storage.service';
import { TokenService } from './auth/token.service';
import { UserService } from './user/user.service';
import { MovieService } from './movie/movie.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AuthService,
    HttpService,
    StorageService,
    TokenService,
    UserService,
    MovieService
  ],
  declarations: []
})
export class ServiceModule { }
