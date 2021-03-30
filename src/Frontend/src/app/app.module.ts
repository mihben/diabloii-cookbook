import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {FormBuilder, FormsModule, ReactiveFormsModule} from '@angular/forms';  

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RuneService } from 'src/shared/services/rune.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatGridListModule } from '@angular/material/grid-list';
import { CharacterService } from 'src/shared/services/character.service';
import { RuneComponent } from './components/rune/rune.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CreateCharacterComponent } from './components/create-character/create-character.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';
import { DeleteConfirmationDialogComponent } from './components/delete-confirmation-dialog/delete-confirmation-dialog.component';
import { FilterService } from 'src/shared/services/filter.service';

@NgModule({
  declarations: [
    AppComponent,
    RuneComponent,
    CreateCharacterComponent,
    DeleteConfirmationDialogComponent
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
    ReactiveFormsModule
  ],
  providers: [RuneService, CharacterService, FormBuilder, FilterService],
  entryComponents: [CreateCharacterComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
