import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { SampleModule } from './sample/sample.module';
import { AuthSharedModule } from './auth/auth-shared.module';
import { OAuthModule } from 'angular-oauth2-oidc';
import { HttpClientModule } from '@angular/common/http';
import { GlobalAdminUsersModule } from './GlobalAdminUsers/global-admin-users/global-admin-users.module';
import { RegisterModule} from './register/register/register.module';
@NgModule({
  declarations: [
    AppComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SampleModule,
    AuthSharedModule,
    HttpClientModule,
    GlobalAdminUsersModule,
    RegisterModule,
    OAuthModule.forRoot({
      resourceServer: {
        sendAccessToken: true,
        allowedUrls: [
          'http://localhost:3300'
          , 'http://localhost:3500'
        ]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
