import { Component, OnInit } from '@angular/core';
import { BookmarksService, Bookmarks } from '../../services/bookmarks.service';
import { userInfo } from 'os';
import { AuthService } from 'src/app/auth/services/auth.service';
import { CustomUser } from 'src/app/auth/models/user';
import { timingSafeEqual } from 'crypto';
import { CoursesService } from '../../services/courses.service';



@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.scss']
})
export class BookmarksComponent implements OnInit {

  bookmarks: Bookmarks[] = [];
  isAuthenticated: boolean;
  user: CustomUser;

  constructor(private service: BookmarksService, private authService: AuthService, private courseService: CoursesService) { }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);
    this.service.getBookmarks()
    .subscribe(data => this.bookmarks = data);
  }

  onDelete(id: string) {
    this.service.deleteBookmark(id)
    .subscribe(data => {
      const indexToDelete = this.bookmarks.findIndex((mark: Bookmarks) => mark.Id === id);
      this.bookmarks.splice(indexToDelete, 1);
    });
  }

  onCourseClick(id: string)
  {
    this.courseService.getCourses(id);
  }

  parseUrl(url: string) {
    return 'https://www.google.com/search?q=' + url;
  }

}
