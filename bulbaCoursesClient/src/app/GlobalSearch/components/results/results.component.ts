import { Component, OnInit } from '@angular/core';
import { SearchService, Courses } from '../../services/search.service';


@Component({
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {

  courses: Courses[] = [];
  page = 2;
  pageSize = 2;

  constructor(private service: SearchService) { }

  ngOnInit() {
    this.service.search()
    .subscribe(data => this.courses = data);
  }

}
