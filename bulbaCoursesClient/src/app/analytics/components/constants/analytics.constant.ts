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
}
