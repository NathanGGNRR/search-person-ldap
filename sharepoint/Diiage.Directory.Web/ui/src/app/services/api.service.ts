import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable, throwError, EMPTY} from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { PagedData, Query } from '../models/tables/core';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private httpClient: HttpClient) { }
  public isAuthenticated = false;

  private getRawResponse(partialUrl: string, isAuthenticated: boolean, httpMethod: string, body?: any, ignoreError?: boolean): Observable<ArrayBuffer> {
      let response: Observable<ArrayBuffer>;
      this.isAuthenticated = isAuthenticated;

      if (isAuthenticated) {
          response = this.httpClient.request(
            httpMethod,
            environment.mainApiUrl + partialUrl,
            {
                observe: 'body',
                responseType: 'arraybuffer',
                body: body,
                headers: new HttpHeaders({ 'Content-Type': 'application/json' })
            })
            .pipe(catchError(r => this.handleError<ArrayBuffer>(environment.mainApiUrl + partialUrl, isAuthenticated, httpMethod, r, ignoreError)));
      }
      else {
          response = throwError(new Error('User not authenticated from API call.'))
              .pipe(catchError(r => this.handleError<ArrayBuffer>(environment.mainApiUrl + partialUrl, isAuthenticated, httpMethod, r, ignoreError)));
      }

      return response;
  }

  private getResponse<T>(partialUrl: string, isAuthenticated: boolean, httpMethod: string, isPartialUrl: boolean = true, body?: any, ignoreError?: boolean): Observable<T> {
      let response: Observable<T>;
      this.isAuthenticated = isAuthenticated;

      if (isAuthenticated) {
          response = this.httpClient.request<T>(
            httpMethod,
            isPartialUrl ? environment.mainApiUrl + partialUrl : partialUrl,
            {
                body: body
            })
            .pipe(catchError(r => this.handleError<T>(environment.mainApiUrl + partialUrl, isAuthenticated, httpMethod, r, ignoreError)));
      }
      else {
          response = throwError(new Error('User not authenticated from API call.'))
              .pipe(catchError(r => this.handleError<T>(environment.mainApiUrl + partialUrl, isAuthenticated, httpMethod, r, ignoreError)));
      }

      return response;
  }

  getRaw(url: string, isAuthenticated: boolean): Observable<ArrayBuffer> {
      return this.getRawResponse(url, isAuthenticated, 'GET');
  }

  private download(url: string): void {
      window.location.href = url;
  }

  get<T = any>(url: string, isAuthenticated: boolean, isPartialUrl: boolean = true, ignoreError?: boolean): Observable<T> {
      return this.getResponse<T>(url, isAuthenticated, 'GET', isPartialUrl, null, ignoreError);
  }

  get2<T = any>(url: string, isAuthenticated: boolean, isPartialUrl: boolean = false, ignoreError?: boolean): Observable<T> {
    return this.getResponse<T>(url, isAuthenticated, 'GET', isPartialUrl, null, ignoreError);
  }

  getPage<T>(url: string, isAuthenticated: boolean, query: Query): Observable<PagedData<T>> {
      return this.get(url + (url.indexOf('?') > -1 ? '&' : '?') + query.toOData(), isAuthenticated)
      .pipe(map(r => new PagedData(r.items, r.count)));
  }

  post<T = any>(url: string, isAuthenticated: boolean, body?: any): Observable<T> {
      return this.getResponse<T>(url, isAuthenticated, "POST", body);
  }

  delete<T = any>(url: string, isAuthenticated: boolean, body?: any): Observable<T> {
      return this.getResponse<T>(url, isAuthenticated, "DELETE", body);
  }

  patch<T = any>(url: string, isAuthenticated: boolean, body: any): Observable<T> {
      return this.getResponse<T>(url, isAuthenticated, "PATCH", body);
  }

  put<T = any>(url: string, isAuthenticated: boolean, body: any): Observable<T> {
      return this.getResponse<T>(url, isAuthenticated, "PUT", body);
  }

  head<T = any>(url: string, isAuthenticated: boolean): Observable<T> {
      return this.getResponse<T>(url, isAuthenticated, "HEAD");
  }

  private handleError<T>(url: string, isAuthenticated: boolean, httpMethod: string, response: any, ignoreError?: boolean): Observable<T> {
      this.isAuthenticated = isAuthenticated;
      if (!ignoreError) {
          if (response.error && response.error.type && response.status === 500) {
            console.error(`[${response.error.type}-${response.error.subType}] - ${response}`);
          } else if (response.error && response.status === 401) {
            console.error(`[Error-Unauthorized] - ${response.error}`);
          } else {
            console.error(`[Error-Network] - ${response}`);
          }
      }

      return EMPTY;
  }
}
