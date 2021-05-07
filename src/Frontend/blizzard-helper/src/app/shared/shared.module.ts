import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AssetPipe } from './pipes/asset.pipe';
import { YesNoPipe } from './pipes/yes-no.pipe';
import { RuneComponent } from './components/rune/rune.component';
import { LoadingScreenComponent } from './components/loading-screen/loading-screen.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmationComponent } from './components/confirmation/confirmation.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { SsoRedirectComponent } from './components/sso-redirect/sso-redirect.component';

@NgModule({
  declarations: [
    NotFoundComponent,
    AssetPipe,
    YesNoPipe,
    RuneComponent,
    LoadingScreenComponent,
    ConfirmationComponent,
    NavigationComponent,
    SsoRedirectComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule,
  ],
  exports: [
    AssetPipe,
    YesNoPipe,
    RuneComponent,
    LoadingScreenComponent,
    NavigationComponent
  ],
  providers: [  
  ]
})
export class SharedModule { }
