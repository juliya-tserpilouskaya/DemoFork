import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User, CustomUser } from '../models/user';
import { AuthConfig, OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';

const config: AuthConfig = {
  clientId: 'external_test',
  dummyClientSecret: 'secret',
  oidc: false,
  scope: 'openid profile api',
  issuer: 'http://localhost:44382',
  logoutUrl: '/',
  requireHttps: false
};

@Injectable()
export class AuthService {

  // BehaviorSubject saves last value
  // setup false as default (no logged in user)
  private authSubject = new BehaviorSubject<boolean>(false);

  private userSubject = new BehaviorSubject<CustomUser>(null);

  constructor(private oauthService: OAuthService, private router: Router) {
    oauthService.configure(config);
    oauthService.tokenValidationHandler = new JwksValidationHandler();
    oauthService.loadDiscoveryDocument().then(() => this.loadUserInfo());
  }

  // read-only property
  get isAuthenticated$() {
    return this.authSubject.asObservable();
  }

  // read-only property
  get user$() {
    return this.userSubject.asObservable();
  }

  async login(username: string, password: string) {
    // only for example
    try {
      const user = await this.oauthService.fetchTokenUsingPasswordFlowAndLoadUserProfile(username, password) as CustomUser;

      this.authSubject.next(user != null);
      this.userSubject.next(user);

      this.router.navigate(['/']);
    } catch (error) {

    }
  }

  logout() {
    // only for example
    this.oauthService.logOut();
    this.authSubject.next(false);
    this.userSubject.next(null);
  }

  private loadUserInfo() {
    if (this.oauthService.hasValidAccessToken()) {
      const claims = this.oauthService.getIdentityClaims();
      const user = Object.assign(<CustomUser>{}, claims);
      this.authSubject.next(true);
      this.userSubject.next(user);
    }
  }
}
