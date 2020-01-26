import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseComponent } from './components/course/course.component';
import { VideoplayerComponent } from './components/videoplayer/videoplayer.component';
import { VgCoreModule } from 'videogular2/compiled/core';
import { VgControlsModule } from 'videogular2/compiled/controls';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';
import { MainvideoComponent } from './components/mainvideo/mainvideo.component';
import { AddCourseComponent } from './components/add-course/add-course.component';
import { FormsModule }   from '@angular/forms';
import { AddVideoProfComponent } from './components/add-video-prof/add-video-prof.component';
import { NgbdTabsetSelectbyid } from './components/tabset-selectbyid/tabset-selectbyid.component';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UploadVideoComponent } from './components/upload-video/upload-video.component';

@NgModule({
  declarations: [
    CourseComponent,
    VideoplayerComponent,
    MainvideoComponent,
    AddCourseComponent,
    AddVideoProfComponent,
    NgbdTabsetSelectbyid,
    UploadVideoComponent,
    ],
    
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserModule,
    NgbModule,
    VgCoreModule,
    VgControlsModule,
    HttpClientModule,
    FormsModule
  ],//bootstrap: [TabsetComponent],
 
  providers: [
    //VideoService
  ],
 exports: [NgbdTabsetSelectbyid]
})
export class VideoModule { }
