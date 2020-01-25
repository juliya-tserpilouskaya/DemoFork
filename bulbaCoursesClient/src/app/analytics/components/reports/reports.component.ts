import { Component, OnInit } from '@angular/core';
import { CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';
import { ReportsService } from '../../services/reports.service';
import { ReportShort } from '../models/reportShort';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: [ './reports.component.scss' ]
})
export class ReportsComponent implements OnInit {

  isAuthenticated: boolean;
  user: CustomUser;
  reportShorts: ReportShort[] = [];

  constructor(private authService: AuthService, private reportsService: ReportsService) {

  }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);

    this.reportsService.getReports().subscribe(data => this.reportShorts = data);
  }

  deleteReport(id: string) {
    this.reportsService.deleteReport(id);
    this.reportsService.getReports();
  }
}
