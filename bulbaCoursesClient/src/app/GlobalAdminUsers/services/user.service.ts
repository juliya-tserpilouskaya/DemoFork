import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';
import { CustomUser } from 'src/app/auth/models/user';
import { UserProfile } from '../models/user-profile';
import { catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})

export class UserService {
  private url = 'https://localhost:44352/api/users';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };
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
  const params = new HttpParams().set('id', id);
  return this.http.delete('https://localhost:44352/api/users/' , { params })
  .subscribe(
    result => console.log(result),
    err => console.error(err)
  );
}
}
