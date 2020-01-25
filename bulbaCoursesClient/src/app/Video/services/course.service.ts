import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private client: HttpClient) { }

  getCourse() {
    return this.client.get<CourseShort[]>('https://localhost:44369/api/courses');
  }
}

 export interface  CourseShort {
    CourseId (string, optional),
    Name (string, optional),
    Level (integer, optional),
    Description (string, optional),
    Price (number, optional)
  }

