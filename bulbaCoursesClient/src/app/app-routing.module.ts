import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SampleComponent } from './sample/components/sample/sample.component';
import { LoginComponent } from './auth/components/login/login.component';
import { UsersComponent } from './GlobalAdminUsers/components/users/users.component';
import { RegisterComponent } from './register/register/register.component';


const routes: Routes = [
  { path: '', component: SampleComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: UsersComponent},
  { path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
