import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './components/menu/menu.component';
import { CourseComponent} from './components/course/course.component';
import { VideoComponent} from './components/video/video.component';
import { ResultListComponent} from './components/result-list/result-list.component';



@NgModule({
  declarations: [MenuComponent, CourseComponent, VideoComponent, ResultListComponent],
  imports: [
    CommonModule
  ]
})
export class VideoModule { }
