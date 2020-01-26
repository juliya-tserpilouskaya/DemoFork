import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dashboard, DashboardNew } from '../components/models/dashboards.model';
import { AnalyticsConstants } from '../components/constants/analytics.constant';

@Injectable()
export class DashboardsService {
  private dashboardsUrl = AnalyticsConstants.ANALYTICS_URL_DASHBOARDS_BYREPORTID;
  private dashboardUrl = AnalyticsConstants.ANALYTICS_URL_DASHBOARD;
  private deleteDashboardUrl = AnalyticsConstants.ANALYTICS_URL_DASHBOARDS_DELETE;
  private newDashboardUrl = AnalyticsConstants.ANALYTICS_URL_DASHBOARDS_NEW;
  private updateDashboardUrl = AnalyticsConstants.ANALYTICS_URL_DASHBOARDS_UPDATE;

  constructor(private httpClient: HttpClient) {
  }

  getDashboards(reportId: string) {
    return this.httpClient.get<Dashboard[]>(this.dashboardsUrl + reportId);
  }

  getDashboard(id: string) {
    return this.httpClient.get<Dashboard>(this.dashboardUrl + id);
  }

  updateDashboard(report: Dashboard) {
    return this.httpClient.put(this.updateDashboardUrl, report);
  }

  deleteDashboard(id: string) {
    return this.httpClient.delete(this.deleteDashboardUrl + id);
  }

  newDashboard(reportNew: DashboardNew) {
    return this.httpClient.post<DashboardNew>(this.newDashboardUrl, reportNew);
  }
}
