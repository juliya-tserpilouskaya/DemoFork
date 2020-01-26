import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReportShort, Report, ReportNew } from '../components/models/reports.model';
import { AnalyticsConstants } from '../components/constants/analytics.constant';

@Injectable()
export class ReportsService {
  private reportsUrl = AnalyticsConstants.ANALYTICS_URL_REPORTS;
  private reportUrl = AnalyticsConstants.ANALYTICS_URL_REPORT;
  private deleteReportUrl = AnalyticsConstants.ANALYTICS_URL_REPORTS_DELETE;
  private newReportUrl = AnalyticsConstants.ANALYTICS_URL_REPORTS_NEW;
  private updateReportUrl = AnalyticsConstants.ANALYTICS_URL_REPORTS_UPDATE;

  constructor(private httpClient: HttpClient) {
  }

  getReports() {
    return this.httpClient.get<ReportShort[]>(this.reportsUrl);
  }

  getReport(id: string) {
    return this.httpClient.get<Report>(this.reportUrl + id);
  }

  updateReport(report: Report) {
    return this.httpClient.put(this.updateReportUrl, report);
  }

  deleteReport(id: string) {
    return this.httpClient.delete(this.deleteReportUrl + id);
  }

  newReport(reportNew: ReportNew) {
    return this.httpClient.post<ReportNew>(this.newReportUrl, reportNew);
  }
}
