import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Role } from '../models/role';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private url = 'https://localhost:44352/api/roles';
  constructor(private http: HttpClient) { }

  getRoles() {
    return this.http.get<Role[]>(this.url);
}
}
