import { SsoRedirectComponent } from './shared/components/sso-redirect/sso-redirect.component';
import { HomeComponent } from './home/components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'diabloii', loadChildren: () => import('./diabloii/diabloii.module').then(module => module.DiabloiiModule) },
  { path: 'sso-redirect', component: SsoRedirectComponent },
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
