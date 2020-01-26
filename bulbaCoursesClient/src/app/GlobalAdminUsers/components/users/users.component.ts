import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { Role } from '../../models/role';
import { UserService } from '../../services/user.service';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { RoleService } from '../../services/role.service';
import { RoleComponent } from '../role/role.component';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
  providers: [UserService]
})
export class UsersComponent implements OnInit {

  users: Array<User> ;
  dropdownList = [];
  selectedItems: Array<Role>;
  dropdownSettings: IDropdownSettings;
  constructor(private serv: UserService, private roleService: RoleService, private router: Router,
              private loader: NgxUiLoaderService) {
    this.users = new Array<User>();
}

  ngOnInit() {
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'Id',
      textField: 'Name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 10,
      allowSearchFilter: true
    };
    this.loadUsers();
    this.loadRoles();

    // this.dropdownList = [
    //   { item_id: 3, item_text: 'Pune' },
    //   { item_id: 4, item_text: 'Navsari' },
    //   { item_id: 5, item_text: 'New Delhi' }
    // ];
    // this.selectedItems = [
    //   { Id: '1', Name: 'Admin' },
    //   { Id: '2', Name: 'test' }
    // ];
  }
  private loadUsers() {
    this.loader.start();
    this.serv.getUsers().subscribe(
      (data: User[]) => {
            this.users = data;
        });
    this.loader.stop();
}
private loadRoles() {
  this.roleService.getRoles().subscribe((data: Role[]) => {this.dropdownList = data; });
}

onItemSelect(item: Role) {
  console.log(item);
  // this.users.push({Id: item.Id.toString(), Username: item.Name, Email: '', UserRoles: ''});
}
onSelectAll(items: Role) {

  console.log(items);
}
editUser(user: User) {
  this.router.navigate(['/profile', user.Id]);
  console.log(user.Username);
}
deleteUser(user: User) {
  this.serv.deleteUser(user.Id);
  console.log('User deleted ' + user.Username);
  this.loadUsers();
}
}
