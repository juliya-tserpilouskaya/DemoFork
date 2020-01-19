import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../models/user';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'http://localhost:44352/api/users';
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(this.url);
}
}
