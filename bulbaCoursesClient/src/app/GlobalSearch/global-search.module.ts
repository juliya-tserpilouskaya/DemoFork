import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QueryResultComponent } from './components/query-result/query-result.component';
import { BookmarksComponent } from './components/bookmarks/bookmarks.component';
import { CourseItemComponent } from './components/course-item/course-item.component';
import { BookmarksService } from './services/bookmarks.service';
import { QueryResultService } from './services/query-result.service';
import { CourseItemService } from './services/course-item.service';
import { SearchComponent } from './components/search/search.component';
import { SearchService } from './services/search.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ResultsComponent } from './components/results/results.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchCourseComponent } from './components/course/course.component';
import { CourseComponent } from '../DiscountAggregator/components/course/course.component';
import { CoursesService } from './services/courses.service';



@NgModule({
  declarations: [QueryResultComponent, BookmarksComponent, CourseItemComponent, SearchComponent, ResultsComponent, SearchCourseComponent],
  imports: [
    CommonModule, NgbModule, RouterModule, FormsModule, ReactiveFormsModule
  ],
  providers: [BookmarksService, QueryResultService, CourseItemService, SearchService, CourseComponent, CoursesService],
  exports: [QueryResultComponent, BookmarksComponent, CourseItemComponent, SearchComponent, SearchCourseComponent]
})
export class GlobalSearchModule { }
