import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from 'src/shared/services/auth-guard.service';
import { DiabloiiComponent } from './components/diabloii/diabloii.component';

const routes: Routes = [{ path: 'diabloii', loadChildren: () => import('./diabloii-classic/diabloii-classic.module'), canActivate: [AuthGuardService]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
