import { Component, OnInit } from '@angular/core';
import { SearchService, Courses } from '../../services/search.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {

  courses: Courses[] = [];
  page = 2;
  pageSize = 10;
  parameter: string;

  constructor(private service: SearchService, route: ActivatedRoute) { 
    route.params.subscribe(params => this.parameter = params['query'])
  }

  ngOnInit() {
    this.service.search(this.parameter)
    .subscribe(data => this.courses = data);
  }
}
