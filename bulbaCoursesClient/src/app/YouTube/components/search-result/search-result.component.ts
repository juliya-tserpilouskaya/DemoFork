import { Component, OnInit, PipeTransform, Pipe } from '@angular/core';
import { ResultVideo, YoutubeService } from '../../services/youtube.service';
import { AppRoutingModule } from '../../../app-routing.module';
import * as moment from 'moment';
import 'moment/locale/ru';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {

  youtubeService: YoutubeService;
  resultVideos: ResultVideo[] = [];
  channel: string[];
  publichedAt: string;
  durtion: string;

  player: YT.Player;

  savePlayer(player) {
    this.player = player;
    console.log('player instance', player);
  }
  onStateChange(event) {
    console.log('player state', event.data);
  }

  constructor(private service: YoutubeService) {
    this.youtubeService = service;
  }

  ngOnInit() {
    this.youtubeService.result$.subscribe(data => {
      this.resultVideos = data;
    });
  }
}

@Pipe({
  name: 'publishedAt'
})
export class PublishedAtPipe implements PipeTransform {
  transform(date: Date) {
    moment().locale('ru');
    return moment(date).fromNow();
  }
}

@Pipe({
  name: 'duration'
})
export class DurationPipe implements PipeTransform {
  transform(date) {
    if (moment.duration(date).asHours() > 1) {
      return moment.utc(moment.duration(date).asMilliseconds()).format('HH:mm:ss');
    } else {
      return moment.utc(moment.duration(date).asMilliseconds()).format('mm:ss');
    }
  }
}

