import { Http, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import { Injectable } from '@angular/core';

@Injectable()
export class RepositoryBase {
  urlBase: string = 'http://localhost:52646/api/';
  constructor(protected http: Http) { }

  public get(urlSuffix: string, param: any = {}) {
    let urlSuffixCompleted = param ? `${urlSuffix}/?${param}` : `${urlSuffix}`;

    return this.http.get(`${this.urlBase}${urlSuffixCompleted}`)
      .map(resp => resp.json());
  }

  public post(urlSuffix: string, data: any = {}) {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    return this.http.post(`${this.urlBase}${urlSuffix}`, data, options)
      .map(resp => {
        try { return resp.json(); } catch (error) { return `{statusCode: ${resp.status}}`; }
      });
  }
}