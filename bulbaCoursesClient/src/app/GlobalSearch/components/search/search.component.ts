import { Component, OnInit, Input } from '@angular/core';
import { SearchService, Courses } from '../../services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  courses: Courses[] = [];
  page = 2;
  pageSize = 2;

  constructor(private service: SearchService) {

  }

  ngOnInit() {
    this.service.search()
    .subscribe(data => this.courses = data);
  }
}
