import { Component, OnInit } from '@angular/core';
import { DiscountAggregatorService, Domains } from '../../services/discount-aggregator.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  domains: Domains[] = [];

  constructor(private service : DiscountAggregatorService) { }

  ngOnInit() {
    this.service.getCourses()
    .subscribe(data => this.domains = data);
  }

}
