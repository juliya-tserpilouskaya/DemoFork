import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ResultVideo } from '../../models/resultvideo';
import { YoutubeService } from '../../services/youtube.service';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {
  id: string;
  player: YT.Player;
  video: ResultVideo;
  youtubeService: YoutubeService;

  savePlayer(player) {
    this.player = player;
    console.log('player instance', player);
  }
  onStateChange(event) {
    console.log('player state', event.data);
  }

  constructor(private service: YoutubeService, private activateRoute: ActivatedRoute) {
    activateRoute.params.subscribe(params => this.id = params['id']);
    this.youtubeService = service;
  }

  ngOnInit() {
    this.youtubeService.video$.subscribe((video) => this.video = video as ResultVideo);
  }

}
