import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SampleComponent } from './sample/components/sample/sample.component';
import { SearchRequestComponent } from './YouTube/components/search-request/search-request.component';
import { SearchResultComponent } from './YouTube/components/search-result/search-result.component';
import { LoginComponent } from './auth/components/login/login.component';
import { VideoComponent } from './YouTube/components/video/video.component'

const routes: Routes = [
  { path: '', component: SampleComponent, pathMatch: 'full' },
  { path: 'search-request', component: SearchRequestComponent },
  { path: 'video/:id', component: VideoComponent },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
