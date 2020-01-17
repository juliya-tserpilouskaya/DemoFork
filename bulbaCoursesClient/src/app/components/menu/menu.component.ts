import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { User } from 'src/app/auth/models/user';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  isAuthenticated: boolean;
  user: User;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user);
  }

}
