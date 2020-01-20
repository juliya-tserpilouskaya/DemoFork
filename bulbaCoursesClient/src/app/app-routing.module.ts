import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SampleComponent } from './sample/components/sample/sample.component';
import { LoginComponent } from './auth/components/login/login.component';
import { CourseComponent } from './DiscountAggregator/components/course/course.component';
//import { MenuComponent } from './DiscountAggregator/components/menu/menu.component';



const routes: Routes = [
  { path: '', component: SampleComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'discountCourses', component: CourseComponent}
  //{path: 'discountMenu', component: CourseComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
