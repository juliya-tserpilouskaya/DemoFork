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
  couresInput:CourseShortInput;
  parameter: string;
  user: CustomUser;
  authService: AuthService;
  constructor(private service: CourseService, route: ActivatedRoute) {
    route.params.subscribe(params => this.parameter = params['name']);
    authService: AuthService;
  }

  ngOnInit() {
    this.service.getCourse()
      .subscribe(data => this.course = data);
     this.service.getCourse().subscribe(data => this.couresInput) 
  }
  addUser(){
    this.couresInput = new CourseShortInput();
    //this.authService.user$.subscribe((user) => this.user = user as CustomUser);
      
    
    
    this.couresInput.Description = "11111";
    
    this.couresInput.Level=2;
    this.couresInput.Name = 'ttttt';
    this.couresInput.Price=10;
    this.service.setCourse(this.couresInput).subscribe(data => console.log('success', data),
      error => console.log('oops', error)
    );
    //this.service.setCourse();
  }

}

export class  CourseShortInput {
  CourseId :string;
  Name :string;
  Level :number;
  Description:string;
  Price:number;
  }