import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnalyticsService } from './services/analytics.service';
import { AnalyticsComponent } from './components/analytics/analytics.component';
import { ReportsComponent } from './components/reports/reports.component';

@NgModule({
  declarations: [AnalyticsComponent, ReportsComponent],
  imports: [
    CommonModule
  ],
  providers: [AnalyticsService],
  exports: [AnalyticsComponent]
})
export class AnalyticsModule { }
