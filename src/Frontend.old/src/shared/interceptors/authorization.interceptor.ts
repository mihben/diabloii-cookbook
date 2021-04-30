import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {

  constructor(public authService: OAuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (request.url.startsWith('https://eu.battle.net/')) return next.handle(request);
      
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.authService.getIdToken()}`
      }
    });

    return next.handle(request);
  }
}
