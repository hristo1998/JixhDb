import { Injectable } from '@angular/core';
import { HttpService } from '../auth/http.service';
import { Observable } from 'rxjs/Observable';

import { LoginUser } from '../../models/auth/LoginUser';
import { RegisterUser } from '../../models/auth/RegisterUser';
import { StorageService } from '../auth/storage.service';
import { Configs } from '../../shared/configs';
import { TokenService } from '../auth/token.service';
import { User } from '../../models/auth/User';

@Injectable()
export class UserService {

  constructor(private httpService: HttpService,
    private storageService: StorageService,
    private tokenService: TokenService) { }


  getAll(): Observable<any> {
    return this.httpService.get('account');
  }

  getUser(): Observable<any> {
    let token = this.storageService.retrieve(Configs.tokenStorageKey);
    let id = this.tokenService.getClaim(token, "oid")
    return this.getUserById(id);
  }

  getUserById(id: string): Observable<any> {
    return this.httpService.get(`account/${id}`);
  }

  getUsername(): string {
    let token = this.storageService.retrieve(Configs.tokenStorageKey);
    return this.tokenService.getClaim(token, Configs.tokenUsernameClaimKey);
  }

  markUser(id: string): Observable<any> {
    return this.httpService.get(`admin/account/modify/${id}`);
  }

  edit(user: User) {
    this.httpService.put(`account`, user).subscribe(res => console.log(res));
  }

  delete(id: string): Observable<any> {
    return this.httpService.delete(`admin/account/delete/${id}`);
  }

}
