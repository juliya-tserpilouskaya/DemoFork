import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DiscountAggregatorService {

  constructor(private client: HttpClient) { }

  getCourses(){
    return this.client.get<Domains[]>/*('http://www.nbrb.by/API/ExRates/Currencies');*/('https://localhost:44317/api/domains');
  }
}
/*
export interface Domains {
  Cur_ID: number;
  Cur_Code: string;
  Cur_Abbreviation: string;
  Cur_Name: string;
}*/

export interface Domains {
  Id: string;
  DomainName: string;
  DomainURL: string;
}

/*
export interface Courses{
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

declare module namespace {

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

  export interface RootObject {
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
  }*/