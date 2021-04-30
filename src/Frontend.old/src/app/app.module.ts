import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormBuilder, FormsModule, ReactiveFormsModule} from '@angular/forms';  

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RuneService } from 'src/shared/services/rune.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatGridListModule } from '@angular/material/grid-list';
import { CharacterService } from 'src/shared/services/character.service';
import { RuneComponent } from './components/rune/rune.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CreateCharacterComponent } from './components/create-character/create-character.component';
import { MatDialogModule} from '@angular/material/dialog';
import { MatSelectModule} from '@angular/material/select';
import { DeleteConfirmationDialogComponent } from './components/delete-confirmation-dialog/delete-confirmation-dialog.component';
import { FilterService } from 'src/shared/services/filter.service';
import { RuneWordComponent } from './components/rune-word/rune-word.component';
import { AuthGuardService } from 'src/shared/services/auth-guard.service';
import { AuthorizationInterceptor } from 'src/shared/interceptors/authorization.interceptor';
import { AuthConfig, OAuthModule, OAuthModuleConfig, OAuthStorage } from 'angular-oauth2-oidc';
import { DiabloiiComponent } from './components/diabloii/diabloii.component';
import { environment } from 'src/environments/environment';

export const authConfig: AuthConfig = {
  issuer: environment.settings.authorization.issuer,
  tokenEndpoint: `${environment.settings.authorization.issuer}/token`,
  redirectUri: window.location.origin,
  clientId: environment.settings.authorization.clientId,
  dummyClientSecret: environment.settings.authorization.clientSecret,
  useHttpBasicAuth: true,
  responseType: 'code',
  scope: 'openid',
  oidc: true,
  showDebugInformation: true
}

export function storageFactory() : OAuthStorage {
  return localStorage
}

@NgModule({
  declarations: [
    AppComponent,
    RuneComponent,
    CreateCharacterComponent,
    DeleteConfirmationDialogComponent,
    RuneWordComponent,
    DiabloiiComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatGridListModule,
    MatTooltipModule,
    MatDialogModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    OAuthModule.forRoot()
  ],
  providers: [RuneService, CharacterService, FormBuilder, FilterService, AuthGuardService,
    { provide: AuthConfig, useValue: authConfig },
    { provide: OAuthStorage, useFactory: storageFactory },
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizationInterceptor, multi: true }
  ],
  entryComponents: [CreateCharacterComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
