import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { DiscountAggregatorService } from '../../services/discount-aggregator.service';
import { User, CustomUser } from 'src/app/auth/models/user';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss']
})
export class FiltersComponent implements OnInit {

  user : CustomUser;
  filterForm : FormGroup;
  discountAggregatorService : DiscountAggregatorService;

  constructor(private service: DiscountAggregatorService, private formBuilder: FormBuilder, private authService: AuthService) {
    this.filterForm = formBuilder.group({
      domainName:[""],
      categoryName:[""],
      minPrice:[""],
      maxPrice:[""],
      minDiscount:[""],
      maxDiscount:[""]
    });
    this.discountAggregatorService = service;
  }

  ngOnInit() {
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);
  }

  onSubmit(){
    if(this.filterForm.valid){
    
      const dataForm = this.filterForm.value;
      const newSearchCriteria = new  SearchCriteria();
      newSearchCriteria.Domains = dataForm.domainName;
      newSearchCriteria.CourseCategories = dataForm.categoryName;
      newSearchCriteria.MinPrice = dataForm.minPrice; 
      newSearchCriteria.MaxPrice = dataForm.maxPrice; 
      newSearchCriteria.MinDiscount = dataForm.minDiscount; 
      newSearchCriteria.MaxDiscount = dataForm.maxDiscount;  
    }
  }
}

export class SearchCriteria {
  Id: string;
  Domains: string//Domain[];
  CourseCategories: string//CourseCategory[];
  MinPrice: number;
  MaxPrice: number;
  MinDiscount: number;
  MaxDiscount: number;
}
