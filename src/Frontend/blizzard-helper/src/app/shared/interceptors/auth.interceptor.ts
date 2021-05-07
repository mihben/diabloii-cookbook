import { OAuthService } from 'angular-oauth2-oidc';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: OAuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (!request.url.includes('eu.battle.net')){
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.authService.getIdToken()}`
        }
      });
    }     

    return next.handle(request);
  }
}
