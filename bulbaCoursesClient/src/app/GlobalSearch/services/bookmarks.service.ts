import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class  BookmarksService {

  constructor(private client: HttpClient) { }
  getBookmarks() {
    return this.client.get<Bookmarks[]>('https://localhost:44320/api/bookmarks/user/');
  }

  deleteBookmark(id: string) {
    return this.client.delete<Bookmarks[]>('https://localhost:44320/api/bookmarks/' + id);
  }

  addToBookmarks(name: string, description: string, courseid: string) {
    return this.client.post<Bookmarks[]>('https://localhost:44320/api/bookmarks/', {
      Title: name,
      Description: description,
      URL: courseid
    });
  }
}
export interface Bookmarks {
  Id: string;
  UserId: string;
  Title: string;
  Description: string;
  URL: string;
}
