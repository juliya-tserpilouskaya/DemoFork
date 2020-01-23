import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {SearchCourses} from '../components/search-courses/search-courses.component';
import { CustomUser } from 'src/app/auth/models/user';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VideoService {

  resultSubject = new Subject<ResultCourses[]>();
  result$ = this.resultSubject.asObservable();

  constructor(private client: HttpClient) { }

  searchCourses(searchCourses: SearchCourses, user: CustomUser) {

    return this.client.post<ResultCourses[]>('https://localhost:44369/api/search', searchCourses, { headers: {
    UserSub: `${user.sub}`
  }});
}

  getCourses() {
    return this.client.get<ResultCourses[]>('https://localhost:44369/api/courses');
  }
}

export interface ResultCourses {
  Id: string;
  Name: string;
  Author: {
    Id: string;
    Name: string;
    Lastname: string;
  };
  CourseLevel: number;
  Description: string;
  DateTime: Date;
  Price: number;
  Author_Id: string;
}
