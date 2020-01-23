import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Subject } from 'rxjs';
import { CustomUser } from 'src/app/auth/models/user'; 


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

  getCoursesForCriteria(/*user: CustomUser*/){
    console.log('2');
    return this.client.get<Courses[]>('https://localhost:44317/api/courses/Search')//,{ 
      //params: new HttpParams().set('idSearch','2611ccba-7cc2-4cc0-8b3a-03811088a81a')//'100b4ac7-320a-48eb-946a-708acff71bdc')//user.sub)
   
   
    //};
  } 

  //updateSearchCriteria(){

  //}

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