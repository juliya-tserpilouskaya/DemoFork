import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SampleComponent } from './sample/components/sample/sample.component';
import { SearchRequestComponent } from './YouTube/components/search-request/search-request.component';
import { SearchResultComponent } from './YouTube/components/search-result/search-result.component';
import { LoginComponent } from './auth/components/login/login.component';
import { CourseComponent } from './DiscountAggregator/components/course/course.component';
import { VideoComponent } from './YouTube/components/video/video.component';
import { AnalyticsComponent } from './analytics/components/analytics/analytics.component';
import { UsersComponent } from './GlobalAdminUsers/components/users/users.component';
import { RegisterComponent } from './register/register/register.component';
import { PagenotfoundComponent } from './ensure/pagenotfound/pagenotfound.component';
import { BookmarksComponent } from './GlobalSearch/components/bookmarks/bookmarks.component';
import { QueryResultComponent } from './GlobalSearch/components/query-result/query-result.component';
import { CourseItemComponent } from './GlobalSearch/components/course-item/course-item.component';
import { SearchComponent } from './GlobalSearch/components/search/search.component';
import { ResultsComponent } from './GlobalSearch/components/results/results.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'discountAggregator', component: CourseComponent},
  { path: 'search-request', component: SearchRequestComponent },
  { path: 'video/:id', component: VideoComponent },
  { path: 'analytics', component: AnalyticsComponent },
  { path: 'admin', component: UsersComponent},
  { path: 'register', component: RegisterComponent},
  { path: '', component: SampleComponent, pathMatch: 'full' },
  { path: '**', component: PagenotfoundComponent },
  { path: 'bookmarks', component: BookmarksComponent },
  { path: 'query-result', component: QueryResultComponent},
  { path: 'course-items', component: CourseItemComponent},
  { path: 'search', component: SearchComponent},
  { path: 'results/:query', component: ResultsComponent },
  // { path: 'bookmarks/:id', component: BookmarksComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
