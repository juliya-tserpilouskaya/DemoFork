import { Injectable } from '@angular/core';
import { HttpClient,HttpParams} from '@angular/common/http';
//import {CourseShortInput} from '../components/course/course.component';
import{CourseShortInput} from '../components/add-course/add-course.component'

import { AuthService } from 'src/app/auth/services/auth.service';
import { CustomUser } from 'src/app/auth/models/user';
//import {}
@Injectable({
  providedIn: 'root'
})
export class CourseService {
  courseId:string;
  authService: AuthService;
  user:CustomUser
  constructor(private client: HttpClient) { }
  setCourse( course :CourseShortInput) {
    return this.client.post('https://localhost:44369/api/courses',course);
  }
  getCourse() {
    return this.client.get<CourseShort[]>('https://localhost:44369/api/courses');
  }
  deleteCourse(courseId:string){
    return this.client.delete('https://localhost:44369/api/courses/'+courseId);
  }
  infoCourse(courseId:string) {
    return this.client.get('https://localhost:44369/api/courses/'+courseId);
  }

}

 export interface  CourseShort {
    CourseId (string, optional),
    Name :string,
    Level :number, 
    Description: string, 
    Price :number, 
  }

