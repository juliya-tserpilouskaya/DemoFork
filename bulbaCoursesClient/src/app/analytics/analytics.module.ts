import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnalyticsService } from './services/analytics.service';
import { AnalyticsComponent } from './components/analytics/analytics.component';
import { ReportsComponent } from './components/reports/reports.component';
import { ReportsService } from './services/reports.service';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';

@NgModule({
  declarations: [AnalyticsComponent, ReportsComponent],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    TableModule,
    ButtonModule
  ],
  providers: [AnalyticsService, ReportsService],
  exports: [AnalyticsComponent]
})
export class AnalyticsModule { }
