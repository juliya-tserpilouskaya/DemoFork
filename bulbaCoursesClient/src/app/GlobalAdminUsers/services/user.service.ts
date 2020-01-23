import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../models/user';
import { CustomUser } from 'src/app/auth/models/user';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'https://localhost:44352/api/users';
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<User[]>(this.url);
}
register(user: CustomUser) {
  return this.http.post('http://localhost:44382/api/users/register', user);
}
}
