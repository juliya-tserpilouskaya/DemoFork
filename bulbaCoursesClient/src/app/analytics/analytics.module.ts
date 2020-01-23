import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnalyticsService } from './services/analytics.service';
import { AnalyticsComponent } from './components/analytics/analytics.component';

@NgModule({
  declarations: [AnalyticsComponent],
  imports: [
    CommonModule
  ],
  providers: [AnalyticsService],
  exports: [AnalyticsComponent]
})
export class AnalyticsModule { }
