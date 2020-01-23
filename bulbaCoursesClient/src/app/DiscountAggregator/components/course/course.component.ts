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
    console.log('1');
    //this.service.getCourses()
    //.subscribe(data => this.courses = data);
    this.service.getCoursesForCriteria(/*this.user*/).subscribe(data => this.courses = data);
    //console.log(this.user.sub);
  }

  onSubmitCriteria(){
    this.service.getCoursesForCriteria(/*this.user*/)
    .subscribe(data => this.courses = data); 
  }
  

}
