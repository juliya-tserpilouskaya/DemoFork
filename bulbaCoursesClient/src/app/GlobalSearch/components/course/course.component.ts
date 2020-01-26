import { Component, OnInit } from '@angular/core';
import { CoursesService } from '../../services/courses.service';
import { ActivatedRoute } from '@angular/router';
import { Courses } from '../../services/search.service';


@Component({
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class SearchCourseComponent implements OnInit {

  course: Course;
  query: string = "string";
  id: string = "";

  constructor(private service: CoursesService, route: ActivatedRoute) {
    route.params.subscribe(params => this.query = params['query'])
    route.params.subscribe(params => this.id = params['id'])
  }

  ngOnInit() {
    this.service.getCourses(this.id)
    .subscribe(data => this.course = data);
  }
}

export interface Course
{
    Id: string;
    Name: string;
    Category: number;
    Cost: number;
    Complexity: string;
    Description: string;
    Language: string;
    Items: {
      Id: string;
      Name: string;
    };
}
