import { Injectable } from '@angular/core';
import { Router } from '@angular/router'
import { Observable } from 'rxjs/Observable';

import { LoginUser } from '../../models/auth/LoginUser';
import { RegisterUser } from '../../models/auth/RegisterUser';
import { Configs } from '../../shared/configs';
import { StorageService } from './storage.service';
import { HttpService } from './http.service';
import { TokenService } from './token.service';

@Injectable()
export class AuthService {

    constructor(
        private storageService: StorageService,
        private http: HttpService,
        private tokenService: TokenService,
        private router: Router
    ) { }

    login(user: LoginUser): boolean {

        this.http.post('token/token', user)
            .subscribe(
            res => {
                this.storageService.store(Configs.tokenStorageKey, res.token);
                this.router.navigate(['']);
            },
            err => {
                console.log(err);
            });

        return false;
    }

    register(user: RegisterUser): boolean {
        this.http.post('account', user)
            .subscribe(() => this.router.navigate(['login']));
        return false;
    }

    logout(redirectUrl: string = ''): void {
        this.storageService.clear();
        this.router.navigate([redirectUrl]);
    }

    public isLoggedIn(): boolean {
        const token = this.storageService.retrieve(Configs.tokenStorageKey);

        if (token) {
            let decodedToken
            try {
                decodedToken = this.tokenService.decodeToken(token);
            }
            catch (e) {
                console.warn('Stored token is invalid!');
                return false;
            }

            const nbfSeconds = Number(decodedToken['nbf']);
            const expSeconds = Number(decodedToken['exp']);
            const nowSeconds = Date.now() / 1000;

            return (Number.isNaN(nbfSeconds) || nbfSeconds < nowSeconds) &&
                (Number.isNaN(expSeconds) || nowSeconds < expSeconds);
        }

        return false
    }

    public isInRole(role: string): boolean {

        if (this.isLoggedIn()) {
            let token = this.storageService.retrieve(Configs.tokenStorageKey);
            let userRole = this.tokenService.getClaim(token, Configs.tokenRoleClaimKey);
            if(userRole == role)
            {
                return true;
            }
        }

        return false;
    }
}