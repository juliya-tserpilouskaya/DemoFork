import { Component, OnInit, Pipe, PipeTransform } from '@angular/core';
import { CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';
import { YoutubeService } from '../../services/youtube.service';
import { SearchStory } from '../../models/searchstory';
import * as moment from 'moment';
import 'moment/locale/ru';


@Component({
  selector: 'app-search-story',
  templateUrl: './search-story.component.html',
  styleUrls: ['./search-story.component.scss']
})
export class SearchStoryComponent implements OnInit {

  isAuthenticated: boolean;
  user: CustomUser;
  searchStory: SearchStory[] = [];
  story: SearchStory;
  totalItems = this.searchStory.length;

  constructor(private authService: AuthService, private service: YoutubeService) { }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);
    
    this.service.story$.subscribe((story) => this.searchStory = story as SearchStory[]);
  }

  GetStoryForUser() {
    console.log('Get story..');
    this.service.getStory(this.user).subscribe(data => {
      this.searchStory = data;
      this.service.storySubject.next(this.searchStory);
    });
    console.log('Get story completed!');
  }

  DeleteByStoryId(story: SearchStory) {
    console.log('Del story..');
    this.service.delStoryById(story).subscribe(data => {
    },
    (error) => console.log(error),
    () => this.GetStoryForUser()
    );
  }

}
@Pipe({
  name: 'searchDate'
})
export class SearchDatePipe implements PipeTransform {
  transform(date: Date) {
    moment().locale('ru');
    return moment(date).fromNow();
  }
}
