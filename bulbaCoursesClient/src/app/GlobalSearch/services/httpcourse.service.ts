import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpCourseService{

    constructor(private http: HttpClient){ }

    postData(body: string) {
        const myheaders = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
        console.log(body, myheaders);
        return this.http.post('https://localhost:44320/api/courses', body, {headers: myheaders});
    }
}
