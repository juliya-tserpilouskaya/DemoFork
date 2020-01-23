import { Component, OnInit } from '@angular/core';
import { DiscountAggregatorService, Courses } from '../../services/discount-aggregator.service';
import { ActivatedRoute } from '@angular/router';
import { CustomUser } from 'src/app/auth/models/user';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  user : CustomUser;
  courses: Courses[] = [];

  constructor(private service : DiscountAggregatorService) {
   }

  ngOnInit() {
    //this.service.getCourses()
    //.subscribe(data => this.courses = data);
    this.service.getCoursesForCriteria(this.user).subscribe(data => this.courses = data);
  }

  onSubmitCriteria(){
    this.service.getCoursesForCriteria(this.user)
    .subscribe(data => this.courses = data); 
  }
  

}
