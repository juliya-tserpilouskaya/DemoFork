import { Component, OnInit, NgModule } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { FormGroup, FormBuilder, NgModel } from '@angular/forms';
import { DiscountAggregatorService, Courses } from '../../services/discount-aggregator.service';
import { User, CustomUser } from 'src/app/auth/models/user';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss']
})
export class FiltersComponent implements OnInit {

  searchResult : Courses[] = [];
  user : CustomUser;
  filterForm : FormGroup;
  discountAggregatorService : DiscountAggregatorService;
  courses: Courses[] = [];

  constructor(private service: DiscountAggregatorService, private formBuilder: FormBuilder, private authService: AuthService) {
    this.filterForm = formBuilder.group({
      domainName:NgModel,
      categoryName:NgModel,
      minPrice:NgModel,
      maxPrice:NgModel,
      minDiscount:NgModel,
      maxDiscount:NgModel
    });
    this.discountAggregatorService = service;
  }

  ngOnInit() {
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);
  }
  
  onSubmitCriteria(){
    console.log('123')
    this.service.getCoursesForCriteria(/*this.user*/)
    .subscribe(data => this.courses = data); 
  }

  onSubmit(){
    if(this.filterForm.valid){
    
      const dataForm = this.filterForm.value;
      const newSearchCriteria : SearchCriteria = {
        Domains : dataForm.domainName,
        CourseCategories: dataForm.categoryName,
        MinPrice : dataForm.minPrice,
        MaxPrice : dataForm.maxPrice, 
        MinDiscount : dataForm.minDiscount, 
        MaxDiscount : dataForm.maxDiscount 
      };
    }
  }
}

export class SearchCriteria {
  Id?: string;
  Domains: string//Domain[];
  CourseCategories: string//CourseCategory[];
  MinPrice: number;
  MaxPrice: number;
  MinDiscount: number;
  MaxDiscount: number;
}
