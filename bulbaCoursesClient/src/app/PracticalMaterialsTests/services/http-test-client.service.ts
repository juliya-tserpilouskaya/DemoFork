import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MTest_MainInfo } from '../models/test/Test/MTest_MainInfo';
import { MReaderChoice_MainInfo } from '../models/WorkWithResultTest/MReaderChoice_MainInfo';

@Injectable()
export class HttpService {

    constructor(private http: HttpClient) { }

    private url_1 = 'https://localhost:44333/api/WorkWithTest/GetTestById?TestId=2';

    private url_2 = 'https://localhost:44333/api/WorkWithTest/ResultTestStructure?TestId=2';

    private url_3 = 'https://localhost:44333/api/WorkWithTest/CheckTest';

    getData() {

        return this.http.get<MTest_MainInfo>(this.url_1);
    }

    getResultTestStructure() {

      return this.http.get<MReaderChoice_MainInfo>(this.url_2);
    }

    postTestResult(readerChoice_MainInfo: MReaderChoice_MainInfo) {

      return this.http.post(this.url_3, readerChoice_MainInfo);
    }
}

