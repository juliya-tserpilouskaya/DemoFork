import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SampleComponent } from './sample/components/sample/sample.component';
import { LoginComponent } from './auth/components/login/login.component';
import { CourseComponent } from './DiscountAggregator/components/course/course.component';
// import { MenuComponent } from './DiscountAggregator/components/menu/menu.component';
import { BookmarksComponent } from './GlobalSearch/components/bookmarks/bookmarks.component';
import { QueryResultComponent } from './GlobalSearch/components/query-result/query-result.component';
import { CourseItemComponent } from './GlobalSearch/components/course-item/course-item.component';
import { SearchComponent } from './GlobalSearch/components/search/search.component';
import { ResultsComponent } from './GlobalSearch/components/results/results.component';


const routes: Routes = [
  { path: '', component: SampleComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'discountCourses', component: CourseComponent},
  // {path: 'discountMenu', component: CourseComponent},
  { path: 'bookmarks', component: BookmarksComponent },
  { path: 'query-result', component: QueryResultComponent},
  { path: 'course-items', component: CourseItemComponent},
  { path: 'search', component: SearchComponent},
  { path: 'results', component: ResultsComponent },
  // { path: 'bookmarks/:id', component: BookmarksComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
