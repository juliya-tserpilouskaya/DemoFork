import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Subject, BehaviorSubject } from 'rxjs';
import { SearchStory } from '../models/searchstory';
import { CustomUser } from 'src/app/auth/models/user';
import { ResultVideo } from '../models/resultvideo';
import { SearchRequest } from '../models/searchrequest';

@Injectable({
  providedIn: 'root'
})
export class YoutubeService {

  resultSubject = new BehaviorSubject<ResultVideo[]>(null);
  result$ = this.resultSubject.asObservable();

  videoSubject = new BehaviorSubject<ResultVideo>(null);
  video$ = this.videoSubject.asObservable();

  constructor(private client: HttpClient) { }

  searchVideo(searchRequest: SearchRequest, user: CustomUser) {

    return this.client.post<ResultVideo[]>('http://localhost:60601/api/SearchRequest', searchRequest, {
      headers: {
        UserSub: `${user.sub}`
      }
    });
  }

  getStory(user: CustomUser) {
    console.log('Get stories on service, item = ', user.sub);
    return this.client.get<SearchStory[]>(`http://localhost:60601/api/story/${user.sub}`);
  }

  delStoryById(story: SearchStory) {
    console.log('Del story on service, item = ', story.Id);
    return this.client.put(`http://localhost:60601/api/story/hide`, story.Id);
  }
}


