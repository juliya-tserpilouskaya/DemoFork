import { Component, OnInit } from '@angular/core';
import { SearchService, Courses } from '../../services/search.service';
import { ActivatedRoute } from '@angular/router';
import { BookmarksService} from '../../services/bookmarks.service';


@Component({
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {

  courses: Courses[] = [];
  page = 2;
  pageSize = 10;
  parameter: string;

  constructor(private service: SearchService, private bookmarkService: BookmarksService, route: ActivatedRoute) {
    route.params.subscribe(params => this.parameter = params['query']);
  }

  ngOnInit() {
    this.service.search(this.parameter)
    .subscribe(data => this.courses = data);
  }

  onAddToBookmarks(name: string, description: string, courseid: string) {
    this.bookmarkService.addToBookmarks(name, description, courseid)
    // .subscribe(data => console.log(data));
    .subscribe();
  }
}
