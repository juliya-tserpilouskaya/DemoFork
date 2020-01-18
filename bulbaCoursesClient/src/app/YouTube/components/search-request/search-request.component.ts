import { Component, OnInit } from '@angular/core';
import { ResultVideo, YoutubeService } from '../../services/youtube.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-search-request',
  templateUrl: './search-request.component.html',
  styleUrls: ['./search-request.component.scss']
})
export class SearchRequestComponent implements OnInit {

  resultVideos: ResultVideo[] = [];
  searchForm: FormGroup;
  parameter: string;


  constructor(private service: YoutubeService, route: ActivatedRoute, fb: FormBuilder) {
    // route.params.subscribe(params => this.parameter = params['name']);
    this.searchForm = fb.group({
      title: [''],
      published: ['Any'],
      definition: ['Any'],
      dimension: ['Any'],
      duration: ['Any'],
      caption: ['Any'],
    });

  }

  onSubmit() {
    if (this.searchForm.valid) {
      const dataForm = this.searchForm.value;

      const searchRequest =  new SearchRequest();
      searchRequest.Title = dataForm.title;
      searchRequest.Definition = dataForm.definition;
      searchRequest.Dimension = dataForm.dimension;
      searchRequest.Duration = dataForm.duration;
      searchRequest.VideoCaption = dataForm.caption;

      switch (dataForm.published) {
        case 'Hour':
          searchRequest.PublishedBefore = new Date();
          searchRequest.PublishedAfter = new Date();
          searchRequest.PublishedAfter.setHours(searchRequest.PublishedBefore.getHours() - 1);
          break;
        case 'Today':
          searchRequest.PublishedBefore = new Date();
          searchRequest.PublishedAfter = new Date();
          searchRequest.PublishedAfter.setHours(0, 0, 0, 0);
          break;
        case 'Week':
          searchRequest.PublishedBefore = new Date();
          searchRequest.PublishedAfter = new Date();
          searchRequest.PublishedAfter.setDate(searchRequest.PublishedBefore.getDate() - searchRequest.PublishedBefore.getDay());
          break;
        case 'Month':
          searchRequest.PublishedBefore = new Date();
          searchRequest.PublishedAfter = new Date();
          searchRequest.PublishedAfter.setDate(0);
          break;
        case 'Year':
          searchRequest.PublishedBefore = new Date();
          searchRequest.PublishedAfter = new Date();
          searchRequest.PublishedAfter.setMonth(0, 0);
          break;
        case 'Any':
          searchRequest.PublishedBefore = null;
          searchRequest.PublishedAfter = null;
          break;
        default:
      }
      this.service.searchVideo(searchRequest).subscribe(data => this.resultVideos = data);
    }
  }
  ngOnInit() {
  }
}

export class SearchRequest {
  Id: string;
  Title: string;
  PublishedBefore: Date;
  PublishedAfter: Date;
  Definition: string;
  Dimension: string;
  Duration: string;
  VideoCaption: string;
}
