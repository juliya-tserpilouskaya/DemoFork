import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QueryResultComponent } from './components/query-result/query-result.component';
import { BookmarksComponent } from './components/bookmarks/bookmarks.component';
import { CourseItemComponent } from './components/course-item/course-item.component';
import { BookmarksService } from './services/bookmarks.service';
import { QueryResultService } from './services/query-result.service';
import { CourseItemService } from './services/course-item.service';



@NgModule({
  declarations: [QueryResultComponent, BookmarksComponent, CourseItemComponent],
  imports: [
    CommonModule
  ],
  providers: [BookmarksService, QueryResultService, CourseItemService ],
  exports: [QueryResultComponent, BookmarksComponent, CourseItemComponent]
})
export class GlobalSearchModule { }
