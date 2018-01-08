import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { HttpErrorResponse } from '@angular/common/http/src/response';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Configs } from '../../shared/configs';
import { StorageService } from './storage.service';


const responseMapper = (response: Response) => response.text() ? response.json() : {}

@Injectable()
export class HttpService {


  constructor(private http: Http,
    private storageService: StorageService) { }

  private createRequestOptions(httpMethod: string): RequestOptions {
    const token = this.storageService.retrieve(Configs.tokenStorageKey);
   
    return new RequestOptions({
      headers: new Headers({
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`
      }),
      method: httpMethod
    });
  }

  private getFullUrl(url: string): string {
    return Configs.apiBaseUrl + url;
  }

  private executeHttpMethod(httpMethod: string, url: string, data?: { [key: string]: any }): Observable<any> {
    const httpMethodName: string = httpMethod.toLowerCase();
    const fullUrl: string = this.getFullUrl(url);
    const requestOptions: RequestOptions = this.createRequestOptions(httpMethod);

    const req$: Observable<Response> = data ?
      this.http[httpMethodName](fullUrl, data, requestOptions) :
      this.http[httpMethodName](fullUrl, requestOptions);

    return req$
      .map(responseMapper)
      .catch(this.handleError.bind(this));
  }

  public get(url: string): Observable<any> {
    return this.executeHttpMethod('GET', url);
  }

  public post(url: string, data: any): Observable<any> {
    return this.executeHttpMethod('POST', url, data);
  }

  public put(url: string, data: any): Observable<any> {
    return this.executeHttpMethod('PUT', url, data);
  }

  public delete(url: string): Observable<any> {
    return this.executeHttpMethod('DELETE', url);
  }

  // https://angular.io/guide/http#getting-error-details
  private handleError(err: HttpErrorResponse): Observable<any> {
    if (err.error instanceof Error) {
      // A client-side or network error occurred. Handle it accordingly.
      console.log('An error occurred:', err.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.log(`Backend returned code ${err.status}, body was: ${err.error}`);
    }

    return Observable.throw(err);
  }

}
