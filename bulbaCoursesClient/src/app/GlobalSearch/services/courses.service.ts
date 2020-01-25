import { Injectable } from '@angular/core';
import { HttpClient, HttpParams} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {

  course: Course;

  constructor(private client: HttpClient) { }

  getCourses(query: string, id: string) {
    // return this.client.get<Courses[]>('https://my-json-server.typicode.com/typicode/demo/posts');
    return this.client.get<Course>('https://localhost:44320/api/courses/' + id);
  }
}

export interface Course {
    Id: string;
    Name: string;
    Cost: number;
    Complexity: string;
    Description: string;
    Items: {
      Id: string;
      Name: string;
    };
}

export interface BookmarksPost {
  // Title: string;
  CourseId: string;
  // cat
}
