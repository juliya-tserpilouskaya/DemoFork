import { Component, OnInit, OnDestroy } from '@angular/core';
import { CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Dropdown } from 'primeng/dropdown/public_api';
import { Button } from 'primeng/button/button';
import { MenuItem, MessageService } from 'primeng/api';
import { ReportsService } from '../../services/reports.service';
import { DashboardsService } from '../../services/dashboards.service';
import { ReportShort, ReportNew, Report } from '../models/reports.model';
import { Dashboard } from '../models/dashboards.model';
import { ConfirmationDialogService } from '../../ensure/dialog/confirmdialog/confirmdialog.service';
import { Subscription } from 'rxjs';

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

  reportNew: ReportNew = {Name: '', Description: ''};
  isAddingReport: boolean;

  report: Report = {Id: '', Name: '', Description: ''};
  isDetailsReport: boolean;

  dashboards: Dashboard[] = [];

  constructor(
    private authService: AuthService,
    private reportsService: ReportsService,
    private dashboardsService: DashboardsService,
    private loader: NgxUiLoaderService,
    private confirmationDialogService: ConfirmationDialogService,
    private messageService: MessageService
    ) {
      this.isAddingReport = false;
  }

  ngOnInit() {
    this.subscription$.add( this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag) );
    this.subscription$.add( this.authService.user$.subscribe((user) => this.user = user as CustomUser) );

    this.getReports();
    this.getDashboards();

    this.items = [
      {label: 'Add', icon: 'pi pi-plus', command: () => {
        this.showingAddingReport();
      }},
      {label: 'Delete', icon: 'pi pi-times', command: () => {
          this.deleteReport();
      }},
      {separator: true},
      {label: 'Details', icon: 'pi pi-cog', command: () => {
        this.showingDetailsReport();
     }}
    ];
  }
// REPORTS
  getReports( complited: CallableFunction = null) {
      console.log('Get Reports');
      if (complited == null) { this.loader.start(); }
      this.reportsService.getReports().subscribe(
        data => {
          this.reportShorts = data;
          console.log('Data loaded');
          if (complited == null) { this.loader.stop(); }
        },
        () => console.log('Error getReports'),
        () => complited == null ? null : complited()
      );
  }

  detailsReport() {
    console.log( 'Details ' + this.selectedReport.Id.toString());

    this.reportsService.getReport(this.selectedReport.Id).subscribe(
      data => {
        this.report = data;
        console.log('Report details loaded');
        this.isDetailsReport = true;
      },
      () => console.log('Error getReports'),
      () => null
    );
  }

  updateReport() {
    this.hideDetailsReport();

    console.log('Update Report');

    if (this.report.Name.length === 0) {
      const err = {severity: 'warn', summary: 'Bad Report Name.', detail: 'Report not updated.'};
      this.messageService.add(err);
      return;
    }

    const msg = {severity: 'success', summary: 'Update', detail: this.report.Name};
    this.reportsService.updateReport(this.report).subscribe(
      () => null,
      () => {
        console.log('Error updating Report');
        const err = {severity: 'error', summary: 'Error', detail: 'Report not updated.'};
        this.messageService.add(err);
      },
      () => {
        this.getReports(
            () => this.messageService.add(msg)
          );
      }
    );

  }

  hideDetailsReport() {
    this.isDetailsReport = false;
  }

  showingDetailsReport() {
    this.detailsReport();
  }

  addReport() {
    this.hideAddingReport();

    console.log('Add Report');

    if (this.reportNew.Name.length === 0) {
      const err = {severity: 'warn', summary: 'Bad Report Name.', detail: 'Report not created.'};
      this.messageService.add(err);
      return;
    }

    const msg = {severity: 'success', summary: 'Add', detail: this.reportNew.Name};
    this.reportsService.newReport(this.reportNew).subscribe(
      () => null,
      () => {
        console.log('Error adding Report');
        const err = {severity: 'error', summary: 'Report not created', detail: 'A report with the same name already exists.'};
        this.messageService.add(err);
      },
      () => {
        this.getReports(
            () => this.messageService.add(msg)
          );
      }
    );
  }

  showingAddingReport() {
    this.isAddingReport = true;
  }

  hideAddingReport() {
    this.isAddingReport = false;
  }

  deleteReport() {
    const reportName = this.selectedReport.Name;
    const reportId = this.selectedReport.Id;

    this.confirmationDialogService.confirm(
      'Delete Report',
      reportName + '<p>Are you sure you want to delete this report?</p>',
      () => {
        console.log('Delete Report');
        const msg = {severity: 'success', summary: 'Deleted', detail: reportName};
        this.reportsService.deleteReport(reportId).subscribe(
          () => null,
          () => console.log('Error delete Report'),
          () => {
            this.getReports(
                () => this.messageService.add(msg)
              );
          }
        );
      },
      () => console.log('Cancel delete Report.'));
  }

  changeReport() {
    if (this.selectedReport == null) { return; }
    console.log('Select Report.');
    this.getDashboards();
  }

  clearFilter(dropdown: Dropdown, button: Button) {
    dropdown.resetFilter();
    button.disabled = true;
  }

// DASHBOARDS
  getDashboards() {
    console.log('Get Dashboards');

    if (this.selectedReport == null) { return; }

    this.dashboardsService.getDashboards(this.selectedReport.Id).subscribe(
      data => {
        this.dashboards = data;
        console.log('Data loaded');
      },
      () => {
        this.dashboards = [];
        console.log('Error getDashboards. Not found.');
      }
    );
  }

  selectDashboard(dashboard: Dashboard ) {
      console.log('DashboardId ' + dashboard.Id + ' ReportId ' + dashboard.ReportId);
  }

  ngOnDestroy() {
    this.subscription$.unsubscribe();
  }
}
