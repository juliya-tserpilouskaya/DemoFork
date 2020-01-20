import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
  providers: [UserService]
})
export class UsersComponent implements OnInit {
  private usersSubject = new BehaviorSubject<Array<User>>(null);

  users: Array<User> ;
  // = [
  //  {id: 1, name: 'adminTest', age: 25}
  // ];
  constructor(private serv: UserService) {
    this.users = new Array<User>();

    this.users.push({Id: '1', Username: 'adminTest', Email: 'test@gmail.com', Password: '*'});
    this.users.push({Id: '2', Username: 'trush', Email: 'test@gmail.com', Password: '*' });
    this.users.push({Id: '3', Username: 'user', Email: 'test@gmail.com', Password: '*'  });
    this.users.push({Id: '4', Username: 'bot', Email: 'test@gmail.com', Password: '*'  });
    this.users.push({Id: '6', Username: 'fail', Email: 'test@gmail.com',  Password: '*' });
    //this.loadUsers();

}
get userList$() {

  return this.usersSubject.asObservable();
}
  ngOnInit() {
    this.loadUsers();
  }
  private loadUsers() {

    this.serv.getUsers().subscribe(
      (data: User[]) => {
            this.users = data;
        }
        , err => {this.users.push({Id: 'xx2', Username: err, Email: 'xx@gmail.com',  Password: '*' }); }
        , () => {this.users.push({Id: 'ok', Username: 'ok', Email: 'ok@gmail.com',  Password: '*' }); });
}


}
