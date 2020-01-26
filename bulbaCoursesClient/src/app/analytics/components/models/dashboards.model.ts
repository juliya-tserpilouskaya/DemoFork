export interface Dashboard {
  Id: string;
  Name: string;
  ReportId: string;
  ChartId: string;
  Dates: string[];
  Values: number[];
}

export interface DashboardNew {
  Name: string;
  ReportId: string;
  ChartId: number;
}
