import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { User, CustomUser } from 'src/app/auth/models/user';
import { SearchService } from 'src/app/GlobalSearch/services/search.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  isAuthenticated: boolean;
  user: CustomUser;
  @Input() query: string;
  searchService: SearchService;

  constructor(public authService: AuthService, searchService: SearchService, private router: ActivatedRoute) {
    this.searchService = searchService;
    this.query = searchService.query;
   }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);
  }

  onSearchButtonClicked() {
    window.location.href = '/search/results/' + this.query;
  }
}
