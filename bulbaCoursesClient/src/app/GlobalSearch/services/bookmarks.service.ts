import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class  BookmarksService {

  constructor(private client: HttpClient) { }
  getBookmarks() {
    return this.client.get<Domains[]>('https://localhost:44317/api/domains');
  }
}
export interface Domains {
  Id: string;
  DomainName: string;
  DomainURL: string;
}
