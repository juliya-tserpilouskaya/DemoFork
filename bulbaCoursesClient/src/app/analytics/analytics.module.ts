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
import { ToastModule } from 'primeng/toast';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ConfirmationDialogModule } from './ensure/dialog/confirmdialog/confirmdialog.module';
import { ConfirmationDialogService } from './ensure/dialog/confirmdialog/confirmdialog.service';

@NgModule({
  declarations: [AnalyticsComponent, ReportsComponent],
  imports: [
    CommonModule,
    FormsModule,
    BrowserAnimationsModule,
    MessagesModule,
    TableModule,
    ButtonModule,
    ToastModule,
    ListboxModule,
    DropdownModule,
    SplitButtonModule,
    ConfirmDialogModule,
    ConfirmationDialogModule
  ],
  providers: [AnalyticsService, ReportsService, ConfirmationDialogService, ConfirmationService, MessageService],
  exports: [AnalyticsComponent]
})
export class AnalyticsModule { }
