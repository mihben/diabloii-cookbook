import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DiabloiiClassicComponent } from './components/diabloii-classic/diabloii-classic.component';

const routes: Routes = [
  { path: 'classic', component: DiabloiiClassicComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DiabloiiRoutingModule { }