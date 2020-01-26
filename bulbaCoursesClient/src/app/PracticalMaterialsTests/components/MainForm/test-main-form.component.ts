import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-form',
  template:  `<p-tabView>
                <p-tabPanel header="Tests">
                  <app-uset-test-list></app-uset-test-list>
                </p-tabPanel>
                <p-tabPanel header="Statistic">
                    Content 2
                </p-tabPanel>
              </p-tabView>`
})
export class TestMainFormComponent implements OnInit {

  constructor() { }

  ngOnInit() {

  }
}

