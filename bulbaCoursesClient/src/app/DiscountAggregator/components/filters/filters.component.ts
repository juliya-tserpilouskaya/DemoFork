import { Component, OnInit, NgModule, Input } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { FormGroup, FormBuilder, NgModel } from '@angular/forms';
import { DiscountAggregatorService, Courses, SearchCriteria, Category, Domain } from '../../services/discount-aggregator.service';
import { User, CustomUser } from 'src/app/auth/models/user';
import { map } from 'rxjs/operators';
import { from } from 'rxjs';
import { CourseComponent } from '../course/course.component';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss']
})

export class FiltersComponent implements OnInit {
  user: CustomUser;
  discountAggregatorService: DiscountAggregatorService;
  searchCriteria: SearchCriteria;
  domains: Domain[] = [];
  categories: Category[] = [];
  currentCategory: Category;
  tempService: CourseComponent;

  constructor(private service: DiscountAggregatorService, serviceCourses: CourseComponent) {
     this.discountAggregatorService = service;
     this.tempService = serviceCourses;
  }

  ngOnInit() {
   // this.authService.user$.subscribe((user) => this.user = user as CustomUser);
   this.service.getSearchCriteria().subscribe(data => this.searchCriteria = data);
   console.log('get criteria good');
   this.service.getAllCategory().subscribe(data => this.categories = data);
   this.service.getAllDomains().subscribe(data => this.domains = data);
  }

  onSubmitCriteria() {
    console.log('press submit criteria');
    this.service.putUpdateSearchCriteria(this.searchCriteria, this.user)
      .subscribe(data => this.searchCriteria = data);
    console.log('criteria updated');
    // this.service.getCoursesForCriteria(/*this.user*/)
    // .subscribe(data => this.courses = data);

    this.service.getCoursesForCriteria(/*this.user*/)
    .subscribe(data => this.tempService.courses = data);
    console.log('finish load courses!');
  }

  toNumber() {
    console.log(this.currentCategory.Name);
    console.log(this.currentCategory.Title);
    // this.searchCriteria.CourseCategories = null;
    this.searchCriteria.CourseCategories = [this.currentCategory];

    console.log(this.searchCriteria.CourseCategories);
  }
}

