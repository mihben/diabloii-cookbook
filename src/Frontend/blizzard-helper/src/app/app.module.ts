import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { AuthInterceptor } from './shared/interceptors/auth.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeModule } from './home/home.module';
import { AuthConfig, OAuthModule, OAuthStorage } from 'angular-oauth2-oidc';
import { environment } from 'src/environments/environment';

export const authConfig: AuthConfig = {
  issuer: environment.authorization.issuer,
  redirectUri: window.location.origin + '/sso-redirect',
  clientId: environment.authorization.clientId,
  dummyClientSecret: environment.authorization.clientSecret,
  useHttpBasicAuth: true,
  responseType: 'code',
  scope: 'openid',
  oidc: true,
  showDebugInformation: false
}

export function storageFactory() : OAuthStorage {
  return localStorage
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    HttpClientModule,    
    BrowserAnimationsModule,
    HomeModule,
    OAuthModule.forRoot(),
  ],
  providers: [
    HttpClient,  
    { provide: AuthConfig, useValue: authConfig },
    { provide: OAuthStorage, useFactory: storageFactory },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
