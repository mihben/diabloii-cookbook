import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AssetPipe } from './pipes/asset.pipe';
import { YesNoPipe } from './pipes/yes-no.pipe';
import { RuneComponent } from './components/rune/rune.component';
import { LoadingScreenComponent } from './components/loading-screen/loading-screen.component';



@NgModule({
  declarations: [
    NotFoundComponent,
    AssetPipe,
    YesNoPipe,
    RuneComponent,
    LoadingScreenComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    AssetPipe,
    YesNoPipe,
    RuneComponent,
    LoadingScreenComponent
  ]
})
export class SharedModule { }
