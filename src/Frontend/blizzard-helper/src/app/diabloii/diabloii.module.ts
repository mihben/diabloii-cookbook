import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DiabloiiRoutingModule } from './diabloii-routing.module';
import { DiabloiiClassicComponent } from './components/diabloii-classic/diabloii-classic.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { DiabloiiClassisRuneService } from './services/diabloii-classis-rune.service';


@NgModule({
  declarations: [
    DiabloiiClassicComponent
  ],
  imports: [
    CommonModule,
    DiabloiiRoutingModule,
    SharedModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [HttpClient, DiabloiiClassisRuneService]
})
export class DiabloiiModule { }
