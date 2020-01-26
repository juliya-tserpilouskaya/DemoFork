import { Component, OnInit } from '@angular/core';
import { CourseService, CourseShort  } from 'src/app/Video/services/course.service';
import { ActivatedRoute } from '@angular/router';
import { User, CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';
@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  course: CourseShort[] = [];
  //couresInput:CourseShortInput;
  parameter: string;
  user: CustomUser;
  authService: AuthService;
  isAuthenticated: boolean;
  constructor(private service: CourseService, route: ActivatedRoute) {
    route.params.subscribe(params => this.parameter = params['name']);
    authService: AuthService;
  }

  ngOnInit() {
    this.service.getCourse()
      .subscribe(data => this.course = data);
     //this.service.getCourse().subscribe(data => this.couresInput) 
    // this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    // this.authService.user$.subscribe((user) => this.user = user as CustomUser);
  }
  addUser(asd:string){
    this.service.courseId=asd;
    console.log(this.service.courseId);
  }

}

export class  CourseShortInput {
  
  Name :string;
  Level :number;
  Description:string;
  Price:number;
  }