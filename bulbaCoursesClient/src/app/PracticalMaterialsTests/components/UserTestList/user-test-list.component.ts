import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http-test-client.service';
import { MTest_MainInfo } from '../../models/test/Test/MTest_MainInfo';

@Component({
  selector: 'app-uset-test-list',
  template:  `<table>
                <thead>
                  <tr>
                      <th>Name</th>
                      <th>Description</th>
                      <th>Author</th>
                      <th></th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                      <td>{{Test_MainInfo.Name}}</td>
                      <td>Тест по C# для слушателей курса .NET</td>
                      <td>Иванов Иван Иванович</td>
                      <td>
                        <button (click)="increase()">Click</button>
                      </td>
                  </tr>
                  <tr>
                      <td>{{Test_MainInfo.Name}}</td>
                      <td>Тест по JAVA для слушателей курса JAVA</td>
                      <td>Петров Петр Петрович</td>
                      <td>
                        <button (click)="increase()">Click</button>
                      </td>
                  </tr>
                </tbody>
              </table>`,
  providers: [HttpService]
})
export class UserTestListComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  count: number = 0;

  Test_MainInfo: MTest_MainInfo;

    increase(): void {
        this.count++;
  }

  ngOnInit() {

    this.httpService.getData().subscribe((data:MTest_MainInfo) => this.Test_MainInfo=data);
  }
}
