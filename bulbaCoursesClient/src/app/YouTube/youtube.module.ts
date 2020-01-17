import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchRequestComponent } from './components/search-request/search-request.component';
import { SearchStoryComponent } from './components/search-story/search-story.component';
import { SearchResultComponent } from './components/search-result/search-result.component';
import { VideoComponent } from './components/video/video.component';



@NgModule({
  declarations: [SearchRequestComponent, SearchStoryComponent, SearchResultComponent, VideoComponent],
  imports: [
    CommonModule
  ]
})
export class YoutubeModule { }
