import { Component, OnInit, NgModule } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { FormGroup, FormBuilder, NgModel } from '@angular/forms';
import { DiscountAggregatorService, Courses, SearchCriteria } from '../../services/discount-aggregator.service';
import { User, CustomUser } from 'src/app/auth/models/user';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss']
})
export class FiltersComponent implements OnInit {

  searchResult: Courses[] = [];
  user: CustomUser;
  filterForm: FormGroup;
  discountAggregatorService: DiscountAggregatorService;
  courses: Courses[] = [];
  searchCriteria: SearchCriteria;

  constructor(private service: DiscountAggregatorService, private formBuilder: FormBuilder, private authService: AuthService) {
    /*this.filterForm = formBuilder.group({
      domainName: NgModel,
      categoryName: NgModel,
      minPrice: NgModel,
      maxPrice: NgModel,
      minDiscount: NgModel,
      maxDiscount: NgModel
    });*/
     this.discountAggregatorService = service;
  }

  ngOnInit() {
   // this.authService.user$.subscribe((user) => this.user = user as CustomUser);
   this.service.getSearchCriteria()
    .subscribe(data => this.searchCriteria = data);
   console.log('get criteria good');
  }

  onSubmitCriteria() {
    console.log('press submit criteria');
    this.service.putSearch(this.searchCriteria, this.user)
      .subscribe(data => this.searchCriteria = data);
      // .subscribe(data => this.searchCriteria = data);
    console.log('criteria updated');
    this.service.getCoursesForCriteria(/*this.user*/)
    .subscribe(data => this.courses = data);
    console.log('finish load courses!');
  }

  onSubmit() {
    // if (this.filterForm.valid) {

    //   const dataForm = this.filterForm.value;
    //   const newSearchCriteria: SearchCriteria = {
    //    Domains : dataForm.domainName,
    //     CourseCategories: dataForm.categoryName,
    //     MinPrice : dataForm.minPrice,
    //     MaxPrice : dataForm.maxPrice,
    //     MinDiscount : dataForm.minDiscount,
    //     MaxDiscount : dataForm.maxDiscount
    //   };
    // }
  }
}

// export class SearchCriteria {
//   Id?: string;
//   Domains: Domain[]; // string
//   CourseCategories: CourseCategory[]; // string;
//   MinPrice: number;
//   MaxPrice: number;
//   MinDiscount: number;
//   MaxDiscount: number;
// }

export class Domain {
  Id?: string;
  DomainName: string;
  DomainURL: string;
}

export class CourseCategory {
  Id?: string;
  Name: string;
  Title: string;
}
