import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReportShort } from '../components/models/reportShort';
import { AnalyticsConstants } from '../components/constants/analytics.constant';

@Injectable()
export class ReportsService {
  private reports = AnalyticsConstants.ANALYTICS_URL_REPORTS;
  private deleteUrl = AnalyticsConstants.ANALYTICS_URL_REPORTS_DELETE;

  constructor(private httpClient: HttpClient) {
  }

  getReports() {
    return this.httpClient.get<ReportShort[]>(this.reports);
  }

  deleteReport(id: string) {
    this.httpClient.delete(this.deleteUrl + id);
    console.log(this.deleteUrl + id);
  }
}
