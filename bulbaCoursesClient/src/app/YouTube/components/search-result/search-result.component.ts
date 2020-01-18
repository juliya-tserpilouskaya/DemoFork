import { Component, OnInit } from '@angular/core';
import { ResultVideo, YoutubeService } from '../../services/youtube.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {

  resultVideos: ResultVideo[] = [];

  constructor(private service: YoutubeService) { }

  ngOnInit() {
    // this.service.searchVideo().subscribe(data => this.resultVideos = data);
  }

}
