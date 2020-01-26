export interface Dashboard {
  Id: string;
  Name: string;
  ReportId: string;
  ChartId: string;
}

export interface DashboardNew {
  Name: string;
  ReportId: string;
  ChartId: number;
}
