import { Component, OnInit, OnDestroy } from '@angular/core';
import { CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Dropdown } from 'primeng/dropdown/public_api';
import { Button } from 'primeng/button/button';
import { MenuItem, MessageService } from 'primeng/api';
import { ReportsService } from '../../services/reports.service';
import { ReportShort } from '../models/reportShort';
import { ConfirmationDialogService } from '../../ensure/dialog/confirmdialog/confirmdialog.service';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: [ './reports.component.scss' ]
})
export class ReportsComponent implements OnInit, OnDestroy {

  private subscription$: Subscription = new Subscription();

  isAuthenticated: boolean;
  user: CustomUser;
  selectedReport: ReportShort;
  reportShorts: ReportShort[] = [];
  items: MenuItem[];

  constructor(
    private authService: AuthService,
    private reportsService: ReportsService,
    private loader: NgxUiLoaderService,
    private confirmationDialogService: ConfirmationDialogService,
    private messageService: MessageService
    ) {
  }

  ngOnInit() {
    this.subscription$.add( this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag) );
    this.subscription$.add( this.authService.user$.subscribe((user) => this.user = user as CustomUser) );

    this.getReports();

    this.items = [
      {label: 'Delete', icon: 'pi pi-times', command: () => {
          this.deleteReport();
      }},
      {separator: true},
      {label: 'Edit', icon: 'pi pi-cog', command: () => {
        this.editReport();
     }}
    ];
  }

  getReports( complited: CallableFunction = null) {
      console.log('Get Reports');
      if (complited == null) { this.loader.start(); }
      this.reportsService.getReports().pipe(first()).subscribe(
        data => {
          this.reportShorts = data;
          console.log('Data loaded');
          if (complited == null) { this.loader.stop(); }
        },
        () => console.log('Error getReports'),
        () => complited == null ? null : complited()
      );
  }

  deleteReport() {
    const reportName = this.selectedReport.Name.toString();
    const reportId = this.selectedReport.Id.toString();

    this.confirmationDialogService.confirm(
      'Delete Report',
      reportName + '<p>Are you sure you want to delete this report?</p>',
      () => {
        console.log('Delete');
        const msg = {severity: 'success', summary: 'Deleted', detail: reportName};
        this.reportsService.deleteReport(reportId).pipe(first()).subscribe(
          () => null,
          () => console.log('Error delete Report'),
          () => {
            this.getReports(
                () => this.messageService.add(msg)
              );
          }
        );
      },
      () => console.log('Cancel delete.'));
  }

  editReport() {
    console.log( 'Edit ' + this.selectedReport.Id.toString());
    return;
  }

  changeReport() {
    if (this.selectedReport == null) { return; }
    console.log('Select Report.');
  }

  clearFilter(dropdown: Dropdown, button: Button) {
    dropdown.resetFilter();
    button.disabled = true;
  }

  ngOnDestroy() {
    this.subscription$.unsubscribe();
  }
}
