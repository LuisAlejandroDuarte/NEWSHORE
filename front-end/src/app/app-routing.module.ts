import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guads/auth.guard';
import { LoginComponent } from './forms/login/login.component';
import { ViajesComponent } from './forms/viajes/viajes.component';


const routes: Routes = [
  {path: '', redirectTo: 'login',pathMatch: 'full'},
  { path: 'login', component: LoginComponent},
  { path: 'viajes', component: ViajesComponent,canActivate:[AuthGuard]}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
