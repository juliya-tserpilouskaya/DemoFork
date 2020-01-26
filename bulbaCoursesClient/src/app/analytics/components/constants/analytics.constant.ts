export class AnalyticsConstants {

  public static get ANALYTICS_BASE_HTTPS_URL(): string {
    return 'https://localhost:44386';
  }

  public static get ANALYTICS_API_VERSION(): string {
    return '/api/v1/';
  }

  public static get ANALYTICS_URL(): string {
    const url = this.ANALYTICS_BASE_HTTPS_URL + this.ANALYTICS_API_VERSION;
    return url;
  }
// REPORTS
  public static get ANALYTICS_URL_REPORTS(): string {
    const reports = 'reports/';
    const url = this.ANALYTICS_URL + reports;
    return url;
  }

  public static get ANALYTICS_URL_REPORT(): string {
    const id = 'id/';
    const url = this.ANALYTICS_URL_REPORTS + id;
    return url;
  }

  public static get ANALYTICS_URL_REPORTS_DELETE(): string {
    const id = 'id/';
    const url = this.ANALYTICS_URL_REPORTS + id;
    return url;
  }

  public static get ANALYTICS_URL_REPORTS_NEW(): string {
    const url = this.ANALYTICS_URL_REPORTS;
    return url;
  }

  public static get ANALYTICS_URL_REPORTS_UPDATE(): string {
    const url = this.ANALYTICS_URL_REPORTS;
    return url;
  }
// DASHBOARDS
public static get ANALYTICS_URL_DASHBOARDS(): string {
  const dashboards = 'Dashboards/';
  const url = this.ANALYTICS_URL + dashboards;
  return url;
}

public static get ANALYTICS_URL_DASHBOARDS_BYREPORTID(): string {
  const dashboards = 'Dashboards/reportId/';
  const url = this.ANALYTICS_URL + dashboards;
  return url;
}

public static get ANALYTICS_URL_DASHBOARD(): string {
  const id = 'id/';
  const url = this.ANALYTICS_URL_DASHBOARDS + id;
  return url;
}

public static get ANALYTICS_URL_DASHBOARDS_DELETE(): string {
  const id = 'id/';
  const url = this.ANALYTICS_URL_DASHBOARDS + id;
  return url;
}

public static get ANALYTICS_URL_DASHBOARDS_NEW(): string {
  const url = this.ANALYTICS_URL_DASHBOARDS;
  return url;
}

public static get ANALYTICS_URL_DASHBOARDS_UPDATE(): string {
  const url = this.ANALYTICS_URL_DASHBOARDS;
  return url;
}
}
