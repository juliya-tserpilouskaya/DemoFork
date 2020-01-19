import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  users: Array<User>;
  constructor(private serv: UserService) {
    this.users = new Array<User>();
}

  ngOnInit() {
    this.loadUsers();
  }
   // загрузка пользователей
   private loadUsers() {
    this.serv.getUsers().subscribe((data: User[]) => {
            this.users = data; });
}

}
