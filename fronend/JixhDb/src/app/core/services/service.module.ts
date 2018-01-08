import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HttpService } from './auth/http.service';
import { StorageService } from './auth/storage.service';
import { UserService } from './users/user.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    HttpService,
    StorageService,
    UserService
  ],
  declarations: []
})
export class ServiceModule { }
