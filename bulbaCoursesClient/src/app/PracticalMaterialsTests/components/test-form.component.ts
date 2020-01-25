import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http-test-client.service';
import { MTest_MainInfo } from '../models/test/Test/MTest_MainInfo';

@Component({
  selector: 'app-test-form',
  template:  `<p>XXXXXXXXXX</p>
              <p-tabView>
                <p-tabPanel header="Tests">
                  Content 1
                </p-tabPanel>
                <p-tabPanel header="Statistic">
                    Content 2
                </p-tabPanel>
              </p-tabView>`,
  providers: [HttpService]
})
export class TestFormComponent implements OnInit {

  Test_MainInfo: MTest_MainInfo;

  constructor(private httpService: HttpService) { }

  ngOnInit() {

    this.httpService.getData().subscribe((data:MTest_MainInfo) => this.Test_MainInfo=data);
  }
}
