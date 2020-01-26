import { Component, OnInit } from '@angular/core';
import { CourseService, CourseShort  } from 'src/app/Video/services/course.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  course: CourseShort[] = [];

  parameter: string;

  constructor(private service: CourseService, route: ActivatedRoute) {
    route.params.subscribe(params => this.parameter = params['name']);
  }

  ngOnInit() {
    this.service.getCourse()
      .subscribe(data => this.course = data);
  }


}
