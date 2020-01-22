import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VideoService } from './services/video.service';
import { CourseComponent } from './components/course/course.component';
import { VideoplayerComponent } from './components/videoplayer/videoplayer.component';
import { VgCoreModule } from 'videogular2/compiled/core';
import { VgControlsModule } from 'videogular2/compiled/controls';




@NgModule({
  declarations: [
    CourseComponent,
    VideoplayerComponent],
  imports: [
    CommonModule,
    BrowserModule,
    VgCoreModule,
    VgControlsModule,
  ],
  providers: [
    VideoService
  ]
})
export class VideoModule { }
