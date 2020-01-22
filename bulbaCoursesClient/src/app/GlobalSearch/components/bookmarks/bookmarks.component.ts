import { Component, OnInit } from '@angular/core';
import { BookmarksService, Domains } from '../../services/bookmarks.service';

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.scss']
})
export class BookmarksComponent implements OnInit {

  domains: Domains[] = [];

  constructor(private service: BookmarksService) { }

  ngOnInit() {
    this.service.getBookmarks()
    .subscribe(data => this.domains = data);
  }

}
