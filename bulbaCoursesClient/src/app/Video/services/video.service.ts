import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VideoService {

  constructor(private client: HttpClient) { }

  getCourses(){
    return this.client.get<Courses[]>('https://localhost:44369/api/courses');
  }
}

export interface Courses{
  Id: string;
  Name: string;
  CourseLevel: number;
  Description: string;
  Price: number;
}
