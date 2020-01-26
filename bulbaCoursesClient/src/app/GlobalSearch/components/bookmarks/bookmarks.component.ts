import { Component, OnInit } from '@angular/core';
import { BookmarksService, Bookmarks } from '../../services/bookmarks.service';
import { userInfo } from 'os';
import { AuthService } from 'src/app/auth/services/auth.service';
import { CustomUser } from 'src/app/auth/models/user';
import { timingSafeEqual } from 'crypto';



@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.scss']
})
export class BookmarksComponent implements OnInit {

  bookmarks: Bookmarks[] = [];
  isAuthenticated: boolean;
  user: CustomUser;

  constructor(private service: BookmarksService, private authService: AuthService) { }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);
    this.service.getBookmarks()
    .subscribe(data => this.bookmarks = data);
  }

  onDelete(id) {
    // this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    // this.authService.user$.subscribe((user) => this.user = user as CustomUser);
    this.service.deleteBookmark(id)
    .subscribe(data => {
      const indexToDelete = this.bookmarks.findIndex((mark: Bookmarks) => mark.Id === id);
      this.bookmarks.slice(indexToDelete - 1, indexToDelete + 1);

    });
  }

}
