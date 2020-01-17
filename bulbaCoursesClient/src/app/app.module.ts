import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { SampleModule } from './sample/sample.module';
import { AuthSharedModule } from './auth/auth-shared.module';
import { YoutubeModule } from './YouTube/youtube.module';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SampleModule,
    YoutubeModule
    SampleModule,
    AuthSharedModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
