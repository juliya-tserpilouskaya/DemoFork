import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AnalyticsService } from './services/analytics.service';
import { AnalyticsComponent } from './components/analytics/analytics.component';
import { ReportsComponent } from './components/reports/reports.component';
import { ReportsService } from './services/reports.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ListboxModule } from 'primeng/listbox';
import { DropdownModule } from 'primeng/dropdown';
import { MessagesModule } from 'primeng/messages';
import { SplitButtonModule } from 'primeng/splitbutton';

@NgModule({
  declarations: [AnalyticsComponent, ReportsComponent],
  imports: [
    CommonModule,
    FormsModule,
    BrowserAnimationsModule,
    MessagesModule,
    TableModule,
    ButtonModule,
    ListboxModule,
    DropdownModule,
    SplitButtonModule
  ],
  providers: [AnalyticsService, ReportsService],
  exports: [AnalyticsComponent]
})
export class AnalyticsModule { }
