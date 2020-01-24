import { Component, OnInit } from '@angular/core';
import { BookmarksService, Bookmarks } from '../../services/bookmarks.service';

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.scss']
})
export class BookmarksComponent implements OnInit {

  bookmarks: Bookmarks[] = [];

  constructor(private service: BookmarksService) { }

  ngOnInit() {
    this.service.getBookmarks()
    .subscribe(data => this.bookmarks = data);
  }

}
