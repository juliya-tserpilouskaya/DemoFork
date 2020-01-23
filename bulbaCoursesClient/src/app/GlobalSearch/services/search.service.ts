import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private client: HttpClient) {
  }
  search() {
    return this.client.get<Courses[]>('https://my-json-server.typicode.com/typicode/demo/posts');
  }
}

export interface Courses {
  id: string;
  title: string;
}
