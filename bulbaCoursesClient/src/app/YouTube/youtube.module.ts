import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchRequestComponent } from './components/search-request/search-request.component';
import { SearchStoryComponent, SearchDatePipe } from './components/search-story/search-story.component';
import { SearchResultComponent, PublishedAtPipe, DurationPipe } from './components/search-result/search-result.component';
import { VideoComponent } from './components/video/video.component';
import { YoutubeService} from './services/youtube.service';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxYoutubePlayerModule } from 'ngx-youtube-player';
import { AppRoutingModule } from '../app-routing.module';
import { NgxLoadingModule } from 'ngx-loading';

@NgModule({
  declarations: [
    SearchRequestComponent,
    SearchStoryComponent,
    SearchResultComponent,
    VideoComponent,
    PublishedAtPipe,
    DurationPipe,
    SearchDatePipe
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgxYoutubePlayerModule.forRoot(),
    NgxLoadingModule
  ],
  providers: [YoutubeService],
  exports: [SearchRequestComponent]
})
export class YoutubeModule { }

