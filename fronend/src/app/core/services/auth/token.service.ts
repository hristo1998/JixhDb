import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';
import { Configs } from '../../shared/configs';

@Injectable()
export class TokenService {
    constructor(private storage: StorageService) { }

    decodeToken(token: any): any {
        return JSON.parse(atob(token.split(".")[1]));
    }

    getClaim(token: any, claim: string): any {
        let decodedToken = this.decodeToken(token);
        return decodedToken[claim];
    }
}