import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { SampleModule } from './sample/sample.module';
import { AuthSharedModule } from './auth/auth-shared.module';
import { OAuthModule } from 'angular-oauth2-oidc';
import { HttpClientModule } from '@angular/common/http';
import { CourseComponent } from './DiscountAggregator/components/course/course.component';
import { YoutubeModule } from './YouTube/youtube.module';
import { NgxUiLoaderModule, NgxUiLoaderHttpModule } from 'ngx-ui-loader';
import { AnalyticsModule } from './analytics/analytics.module';
import { GlobalAdminUsersModule } from './GlobalAdminUsers/global-admin-users/global-admin-users.module';
import { RegisterModule} from './register/register/register.module';
import { PagenotfoundComponent } from './ensure/pagenotfound/pagenotfound.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    CourseComponent,
    PagenotfoundComponent
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
          'https://localhost:44317',
          'http://localhost:3300',
          'http://localhost:3500',
          'http://localhost:60601',
          'https://localhost:44352'
        ]
      }
    }),
    YoutubeModule,
    AnalyticsModule,
    NgxUiLoaderModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
