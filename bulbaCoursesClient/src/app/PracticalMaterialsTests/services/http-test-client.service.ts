import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MTest_MainInfo } from '../models/test/Test/MTest_MainInfo';

@Injectable()
export class HttpService {

    constructor(private http: HttpClient) { }

    private url = 'https://localhost:44333/api/WorkWithTest/GetTestById?TestId=1';

    getData() {

        return this.http.get<MTest_MainInfo>(this.url);
    }
}

