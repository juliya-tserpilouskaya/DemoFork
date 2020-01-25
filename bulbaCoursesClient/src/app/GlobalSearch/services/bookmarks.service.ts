import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class  BookmarksService {

  constructor(private client: HttpClient) { }
  getBookmarks() {
    // return this.client.get<Bookmarks[]>('https://localhost:44320/api/bookmarks/user/' + id);
    return this.client.get<Bookmarks[]>('https://localhost:44320/api/bookmarks/user/');
  }

  deleteBookmark(id) {
    return this.client.delete<Bookmarks[]>('https://localhost:44320/api/bookmarks/' + id);
  }

  addToBookmarks(id: string, name: string) {
    // return this.client.get<Course>('https://localhost:44320/api/courses/' + id);
    return this.client.put('https://localhost:44320/api/bookmarks/', {
      CourseId: id,
      Name:
    }); //ТУт
  }
}
export interface Bookmarks {
  Id: string;
  UserId: string;
  Title: string;
  Category: string;
  URL: string;
}
