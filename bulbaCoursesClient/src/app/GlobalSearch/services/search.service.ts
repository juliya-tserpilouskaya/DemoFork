import { Injectable } from '@angular/core';
import { HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Subject} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SearchService {

  public query: string = "";
  url: string;
  constructor(private client: HttpClient) {}

  search(qry: string) {
    // return this.client.get<Courses[]>('https://my-json-server.typicode.com/typicode/demo/posts');
    return this.client.get<Courses[]>('https://localhost:44320/api/search/' + qry)
  }
}

// export interface Courses {
//   id: string;
//   title: string;
// }

export interface Courses 
{
    Id: string;
    Name: string;
    Cost: number;
    Complexity: string;
    Description: string;
}