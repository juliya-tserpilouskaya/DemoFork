import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../models/user';
import { CustomUser } from 'src/app/auth/models/user';
import { UserProfile } from '../models/user-profile';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'https://localhost:44352/api/users';
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<User[]>(this.url);
}

getUserProfile(id: string) {
  return this.http.get<UserProfile>('https://localhost:44352/api/users/profile/' + id);
}
register(user: CustomUser) {
  return this.http.post('https://localhost:44352/api/users/register', user);
}
deleteUser(id: string) {
  return this.http.delete('https://localhost:44352/api/users/' + id);
}

}
