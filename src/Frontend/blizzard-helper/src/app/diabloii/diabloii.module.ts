import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DiabloiiRoutingModule } from './diabloii-routing.module';
import { DiabloiiClassicComponent } from './components/diabloii-classic/diabloii-classic.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { DiabloiiClassisRuneService } from './services/diabloii-classis-rune.service';
import { ConfirmationService } from '../shared/services/confirmation.service';
import { DiabloiiClassicNewCharacterComponent } from './components/diabloii-classic-new-character/diabloii-classic-new-character.component';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    DiabloiiClassicComponent,
    DiabloiiClassicNewCharacterComponent
  ],
  imports: [
    CommonModule,
    DiabloiiRoutingModule,
    SharedModule,
    FormsModule,
    HttpClientModule,
    MatDialogModule,
    ReactiveFormsModule
  ],
  providers: [HttpClient, DiabloiiClassisRuneService, ConfirmationService]
})
export class DiabloiiModule { }
