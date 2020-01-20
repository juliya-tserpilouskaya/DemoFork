export interface SearchStory {
  Id: number;
  SearchDate: Date;
  UserId: string;
  SearchRequest_Id: number;
  SearchRequest: {
    SearchRequest_Id: number;
    Title: string;
  };
}
