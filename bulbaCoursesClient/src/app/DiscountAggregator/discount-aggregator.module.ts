import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiscountAggregatorService } from './services/discount-aggregator.service';
import { CourseComponent } from './components/course/course.component';
import { MenuComponent } from './components/menu/menu.component';



@NgModule({
  declarations: [
    CourseComponent, 
    MenuComponent],
  imports: [
    CommonModule
  ],
  providers: [
    DiscountAggregatorService
  ],
  exports: [
    CourseComponent
  ]
})
export class DiscountAggregatorModule { }
