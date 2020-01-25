import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiscountAggregatorService } from './services/discount-aggregator.service';
import { CourseComponent } from './components/course/course.component';
import { MenuComponent } from './components/menu/menu.component';
import { FiltersComponent } from './components/filters/filters.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CourseComponent,
    MenuComponent,
    FiltersComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    DiscountAggregatorService
  ],
  exports: [
    CourseComponent
  ]
})
export class DiscountAggregatorModule { }
