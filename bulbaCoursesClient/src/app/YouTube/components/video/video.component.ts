import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {
  id: string;
  player: YT.Player;

  savePlayer(player) {
    this.player = player;
    console.log('player instance', player);
  }
  onStateChange(event) {
    console.log('player state', event.data);
  }


  constructor(private activateRoute: ActivatedRoute) {
    activateRoute.params.subscribe(params => this.id = params['id']);
  }


  ngOnInit() {
  }

}
