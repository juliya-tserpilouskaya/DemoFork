import { Component, OnInit } from '@angular/core';
import { ResultVideo, YoutubeService } from '../../services/youtube.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import * as moment from 'moment';
import { User, CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';
import { SearchStory } from '../../models/searchstory';
import { SearchRequestService, SearchRequest } from '../../youtube-client-generated';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { pipe } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-search-request',
  templateUrl: './search-request.component.html',
  styleUrls: ['./search-request.component.scss']
})
export class SearchRequestComponent implements OnInit {

  resultVideos: ResultVideo[] = [];
  searchForm: FormGroup;
  parameter: string;
  youtubeService: YoutubeService;
  isAuthenticated: boolean;
  user: CustomUser;

  constructor(private service: YoutubeService,
    route: ActivatedRoute,
    fb: FormBuilder,
    private authService: AuthService,
    private searchService: SearchRequestService,
    private loader: NgxUiLoaderService) {
    // route.params.subscribe(params => this.parameter = params['name']);
    this.searchForm = fb.group({
      title: [''],
      published: ['Any'],
      definition: ['Any'],
      dimension: ['Any'],
      duration: ['Any'],
      caption: ['Any'],
    });
    this.youtubeService = service;
  }

  onSubmit() {
    if (this.searchForm.valid) {
      console.log('Search start..');

      const dataForm = this.searchForm.value;

      // const searchRequest = new SearchRequest();
      // searchRequest.Title = dataForm.title;
      // searchRequest.Definition = dataForm.definition;
      // searchRequest.Dimension = dataForm.dimension;
      // searchRequest.Duration = dataForm.duration;
      // searchRequest.VideoCaption = dataForm.caption;

      const searchRequest: SearchRequest = {
        title: dataForm.title,
        definition: dataForm.definition,
        dimension: dataForm.dimension,
        duration: dataForm.duration,
        videoCaption: dataForm.caption
      };

      switch (dataForm.published) {
        case 'Hour':
          searchRequest.publishedBefore = moment.utc().toDate();
          searchRequest.publishedAfter = moment.utc().subtract(1, 'hour').toDate();
          break;
        case 'Today':
          searchRequest.publishedBefore = moment().toDate();
          searchRequest.publishedAfter = moment().startOf('day').toDate();
          break;
        case 'Week':
          searchRequest.publishedBefore = moment().toDate();
          searchRequest.publishedAfter = moment().startOf('isoWeek').toDate();
          break;
        case 'Month':
          searchRequest.publishedBefore = moment().toDate();
          searchRequest.publishedAfter = moment().startOf('month').toDate();
          break;
        case 'Year':
          searchRequest.publishedBefore = moment().toDate();
          searchRequest.publishedAfter = moment().startOf('year').toDate();
          break;
        default:
          searchRequest.publishedBefore = null;
          searchRequest.publishedAfter = null;
          break;
      }

      // this.service.searchVideo(searchRequest, this.user);

      this.loader.start();

      this.searchService.searchRequestSearchRun(searchRequest).
        pipe(
          map(items => items.map(item => <ResultVideo>{
            Channel: item.channel,
            Channel_Id: item.channelId,
            Title: item.title,
            // TODO: map another fields
          })),
        ).subscribe(data => {
          this.resultVideos.push(...data);
          this.youtubeService.resultSubject.next(this.resultVideos);
          console.log('Search completed!');
          this.loader.stop();
        }, err => this.loader.stop());
    }
  }
  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);
  }
}

// export class SearchRequest {
//   Id: string;
//   Title: string;
//   publishedBefore: Date;
//   publishedAfter: Date;
//   Definition: string;
//   Dimension: string;
//   Duration: string;
//   VideoCaption: string;
// }
