import { Component, OnInit, Injectable } from '@angular/core';
import { DiscountAggregatorService, Courses, SearchCriteria, Domain, Category } from '../../services/discount-aggregator.service';
import { ActivatedRoute } from '@angular/router';
import { CustomUser } from 'src/app/auth/models/user';
import { from } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  user: CustomUser;
  courses: Courses[] = [];

  constructor(private service: DiscountAggregatorService) {
    this.service.getCoursesForCriteria().subscribe(data => this.courses = data);
   }

  ngOnInit() {
    console.log('first load courses');
    // var coursesall = from(this.courses);
    this.service.getCoursesForCriteria().subscribe(data => this.courses = data);
  }
}
