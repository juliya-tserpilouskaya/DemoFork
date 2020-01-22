import { Component, OnInit } from '@angular/core';
import { DiscountAggregatorService, Courses } from '../../services/discount-aggregator.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  courses: Courses[] = [];

  constructor(private service : DiscountAggregatorService) {
   }

  ngOnInit() {
    this.service.getCourses()
    .subscribe(data => this.courses = data);
  }
  

}
