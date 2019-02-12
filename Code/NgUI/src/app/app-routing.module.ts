import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './base/login.component';
import { BugHomeComponent } from './bug/bug-home.component';
import { AuthGuard } from './base/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/bug', pathMatch:'full' },
  { path: 'login', component: LoginComponent },
  { path: 'bug', component: BugHomeComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
