import { Component, OnInit } from '@angular/core';
import { DiscountAggregatorService, Courses, SearchCriteria, Domain, Category } from '../../services/discount-aggregator.service';
import { ActivatedRoute } from '@angular/router';
import { CustomUser } from 'src/app/auth/models/user';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  user: CustomUser;
  courses: Courses[] = [];

  constructor(private service: DiscountAggregatorService) {
   }

  ngOnInit() {
    console.log('1');
    // this.service.getCourses()
    // .subscribe(data => this.courses = data);
    // var coursesd = from([3,4,5]);
    this.service.getCoursesForCriteria().subscribe(data => this.courses = data);

    // var obs = from(courses);
  }

  onSubmitCriteria() {
    this.service.getCoursesForCriteria()
    .subscribe(data => this.courses = data);
  }

}
