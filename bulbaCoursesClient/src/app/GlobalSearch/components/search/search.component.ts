import { Component, OnInit, Input } from '@angular/core';
import { SearchService, Courses } from '../../services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent {

  query: string = "";

  constructor() {
    // this.query = queryService.query;
  }
}
