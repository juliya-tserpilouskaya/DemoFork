import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from '../models/user';

@Injectable()
export class AuthService {

  // BehaviorSubject saves last value
  // setup false as default (no logged in user)
  private authSubject = new BehaviorSubject<boolean>(false);

  private userSubject = new BehaviorSubject<User>(null);

  constructor() { }

  // read-only property
  get isAuthenticated$() {
    return this.authSubject.asObservable();
  }

  // read-only property
  get user$() {
    return this.userSubject.asObservable();
  }

  login() {
    // only for example
    this.authSubject.next(true);
    this.userSubject.next({ id: '123-123-123' });
  }

  logout() {
    // only for example
    this.authSubject.next(false);
    this.userSubject.next(null);
  }
}
