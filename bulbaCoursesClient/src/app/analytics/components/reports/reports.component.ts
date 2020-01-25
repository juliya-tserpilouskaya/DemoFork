import { Component, OnInit } from '@angular/core';
import { CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ReportsService } from '../../services/reports.service';
import { ReportShort } from '../models/reportShort';
import { Dropdown } from 'primeng/dropdown/public_api';
import { Button } from 'primeng/button/button';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: [ './reports.component.scss' ]
})
export class ReportsComponent implements OnInit {

  isAuthenticated: boolean;
  user: CustomUser;
  selectedReport: ReportShort;
  reportShorts: ReportShort[] = [];
  items: MenuItem[];

  constructor(
    private authService: AuthService,
    private reportsService: ReportsService,
    private loader: NgxUiLoaderService
    ) {

  }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);

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

  getReports() {
      console.log('getReports');
      this.loader.start();
      const sub = this.reportsService.getReports().subscribe(
      data => {this.reportShorts = data; console.log('data loaded'); this.loader.stop(); },
      () => console.log('Error getReports'),
      () => sub.unsubscribe);
  }

  deleteReport() {
    console.log(this.selectedReport.Id.toString());
    return;
    const sub = this.reportsService.deleteReport(this.selectedReport.Id.toString()).subscribe(
      () => null,
      () => console.log('Error deleteReport'),
      () => {
        this.getReports();
      }
    );
  }

  editReport() {
    console.log( 'Edit ' + this.selectedReport.Id.toString());
    return;
  }

  changeReport() {
    if (this.selectedReport == null) { return; }
    console.log(this.selectedReport);
  }

  clearFilter(dropdown: Dropdown, button: Button) {
    dropdown.resetFilter();
    button.disabled = true;
}
}
