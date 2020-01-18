import { Component, OnInit } from '@angular/core';
import { ResultVideo, YoutubeService } from '../../services/youtube.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {

  resultVideos: ResultVideo[] = [];
  youtubeService: YoutubeService;

  constructor(private service: YoutubeService, ) {
    this.youtubeService = service;
  }

  ngOnInit() {
    this.youtubeService.result$.subscribe(data => this.resultVideos = data);
  }

}
