import { Component, OnInit } from '@angular/core';
import { NgForm} from '@angular/forms';
//import{CourseShortInput} from '../../models/courseShort'
//import { CourseShortInput } from '../course/course.component';
import { CourseService, CourseShort  } from 'src/app/Video/services/course.service';
import { ActivatedRoute } from '@angular/router';
import { User, CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';

export class CourseShortInput{
  constructor(public name: string, 
              public level: number, 
              public description: string,
              public price:number)
  { }
}

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.scss']
})




export class AddCourseComponent implements OnInit {
  course : CourseShortInput = new CourseShortInput('Name',1,'description',100);
  constructor(private service: CourseService, route: ActivatedRoute) {
    //route.params.subscribe(params => this.parameter = params['name']);
    authService: AuthService;
  }
   

  ngOnInit() {
  } 
  submit(){
    //this. 
    //this.course.Description=form.name;
    this.service.setCourse(this.course).subscribe(data=>console.log(data));
   // console.log(form);
    console.log(this.course.name);
    //form.invalid = true;
    //form.value;
}




}
// export class  CourseShortInput {
//   Name :string,
//   Level: number,
//   Description :string,
//   Price (number, optional)
//   }