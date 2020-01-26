import { Component, OnInit } from '@angular/core';
import { CourseService, CourseShort  } from 'src/app/Video/services/course.service';
import { ActivatedRoute } from '@angular/router';
export class VideoInput{
  constructor(public name: string, 
              public url: string, 
              public description: string,
              public order:number)
  { }
}




@Component({
  selector: 'app-add-video-prof',
  templateUrl: './add-video-prof.component.html',
  styleUrls: ['./add-video-prof.component.scss']
})
export class AddVideoProfComponent implements OnInit {
  video : VideoInput = new VideoInput('Video Name','url','description',1);
  constructor(private service: CourseService, route: ActivatedRoute) {
    //route.params.subscribe(params => this.parameter = params['name']);
  }
  ngOnInit() {
  }
  submit(){
    this.service.addVideoView(this.video).subscribe(data=>console.log(data));
  }
}
