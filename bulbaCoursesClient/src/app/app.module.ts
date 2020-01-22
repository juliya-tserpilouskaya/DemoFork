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
import { GlobalSearchModule } from './GlobalSearch/global-search.module';
// import { BookmarksComponent } from './GlobalSearch/components/bookmarks/bookmarks.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    CourseComponent,
    // BookmarksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SampleModule,
    AuthSharedModule,
    HttpClientModule,
    OAuthModule.forRoot({
      resourceServer: {
        sendAccessToken: true,
        allowedUrls: [
          'https://localhost:44317',
          'http://localhost:3300',
          'http://localhost:3500',
          'https://localhost:44320'
        ]
      }
    }),
    GlobalSearchModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
