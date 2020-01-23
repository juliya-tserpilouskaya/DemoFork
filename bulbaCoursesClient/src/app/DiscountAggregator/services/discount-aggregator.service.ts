import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class DiscountAggregatorService {

  //resultSubject = new Subject<Courses[]>();
  //result$ = this.resultSubject.asObservable();

  constructor(private client: HttpClient) { }

  getCourses() {
    return this.client.get<Courses[]>('https://localhost:44317/api/courses/async');
  }
  /*
  postCourses(){
    return this.client.post<Domains[]>('https://localhost:44317/api/domains');
  }*/
}

export interface Domain {
  Id: string;
  DomainName: string;
  DomainURL: string;
}

export interface Category {
  Id: string;
  Name: string;
  Title: string;
}

export interface Courses {
  Id: string;
  Domain: Domain;
  URL: string;
  Category: Category;
  Title: string;
  Description: string;
  Price: number;
  OldPrice: number;
  DateOldPrice: Date;
  Discount: number;
  DateStartCourse: Date;
  DateChange: Date;
}