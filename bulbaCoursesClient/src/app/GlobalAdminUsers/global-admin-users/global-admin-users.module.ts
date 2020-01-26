import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from '../components/users/users.component';
import { RoleComponent } from '../components/role/role.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ProfileComponent } from '../components/profile/profile.component';
import { ChangePasswordComponent } from '../components/change-password/change-password.component';


@NgModule({
  declarations: [UsersComponent,
     RoleComponent,
     ChangePasswordComponent,
     ProfileComponent
        ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    NgMultiSelectDropDownModule.forRoot()
  ],
  exports: [UsersComponent,
    RoleComponent]
})
export class GlobalAdminUsersModule { }
