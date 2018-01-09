import { Injectable } from '@angular/core';
import { HttpService } from '../auth/http.service';
import { Observable } from 'rxjs/Observable';

import { LoginUser } from '../../models/auth/LoginUser';
import { RegisterUser } from '../../models/auth/RegisterUser';
import { StorageService } from '../auth/storage.service';
import { Configs } from '../../shared/configs';

@Injectable()
export class UserService {

  constructor(private httpService: HttpService,
    private storageService: StorageService) { }


  getAll(): Observable<any> {
    return this.httpService.get('account');
  }

  login(user: LoginUser): boolean {

    this.httpService.post('token/token', user)
      .subscribe(
      res => {
        let expirationTime = new Date();
        expirationTime.setSeconds(expirationTime.getDay() + 1);
        this.storageService.store(Configs.tokenStorageKey, res.token);
        this.storageService.store(Configs.tokenExpirationKey, expirationTime);
        return true;
      },
      err => {
        console.log(err);
        return false;
      });

    return false;
  }

  register(user: RegisterUser): Observable<any> {
    return this.httpService.post('account', user);
  }

  logout() {
    this.storageService.clear();
  }

  public checkLoggedIn(): boolean {
    if (this.storageService.retrieve(Configs.tokenStorageKey)) {
      if (!this.tokenExpired) {
        return true;
      }
    }
    return false;
  }

  private tokenExpired(): boolean {

    let now = new Date().toJSON();
    let expirationTime = this.storageService.retrieve(Configs.tokenExpirationKey);

    if (expirationTime && now < expirationTime) {
      return true;
    }

    return false;
  }
}
