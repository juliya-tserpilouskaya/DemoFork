import { Component, OnInit } from '@angular/core';
import { SampleService } from '../../services/sample.service';

@Component({
  selector: 'app-sample',
  templateUrl: './sample.component.html',
  styleUrls: ['./sample.component.scss']
})
export class SampleComponent implements OnInit {

  constructor(private sampleService: SampleService) { }

  ngOnInit() {
  }

}
