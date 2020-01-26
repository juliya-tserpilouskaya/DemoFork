import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { VideoService } from './services/video.service';
import { CourseComponent } from './components/course/course.component';
import { VideoplayerComponent } from './components/videoplayer/videoplayer.component';
import { VgCoreModule } from 'videogular2/compiled/core';
import { VgControlsModule } from 'videogular2/compiled/controls';
//import { SearchCoursesComponent } from './components/search-courses/search-courses.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';
import{UploadComponent} from './components/upload/upload.component'
import { FileSelectDirective } from 'ng2-file-upload';
import { MainvideoComponent } from './components/mainvideo/mainvideo.component';
import { AddCourseComponent } from './components/add-course/add-course.component';
//import { NgForm} from '@angular/forms';
import { FormsModule }   from '@angular/forms';
@NgModule({
  declarations: [
    CourseComponent,
    VideoplayerComponent,
   // SearchCoursesComponent,
    UploadComponent,
    FileSelectDirective,
    MainvideoComponent,
    AddCourseComponent
    ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserModule,
    VgCoreModule,
    VgControlsModule,
    //NgForm,
    FormsModule
  ],
  providers: [
    //VideoService
  ],
 // exports: [SearchCoursesComponent]
})
export class VideoModule { }
