import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class  BookmarksService {

  constructor(private client: HttpClient) { }
  getBookmarks() {
    return this.client.get<Bookmarks[]>('https://localhost:44320/api/bookmarks');
  }
}
export interface Bookmarks {
  Id: string;
  UserId: string;
  Title: string;
  URL: string;
}
