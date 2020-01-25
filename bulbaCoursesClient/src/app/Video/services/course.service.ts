import { Injectable } from '@angular/core';
import { HttpClient,HttpParams} from '@angular/common/http';
import {CourseShortInput} from '../components/course/course.component';
import { AuthService } from 'src/app/auth/services/auth.service';
//import {}
@Injectable({
  providedIn: 'root'
})
export class CourseService {
  authService: AuthService;
  constructor(private client: HttpClient) { }
  setCourse( course :CourseShortInput) {
    //this.authService.user$
    return this.client.post('https://localhost:44369/api/courses',course);
    
  }
  getCourse() {
    return this.client.get<CourseShort[]>('https://localhost:44369/api/courses');
  }
}

 export interface  CourseShort {
    CourseId (string, optional),
    Name :string,
    Level :number, 
    Description: string, 
    Price :number, 
  }

