import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http-test-client.service';
import { MTest_MainInfo } from '../../models/test/Test/MTest_MainInfo';
import { MReaderChoice_MainInfo } from '../../models/WorkWithResultTest/MReaderChoice_MainInfo';

@Component({
  selector: 'app-test-form',
  template:  `<div>
                <h1>{{testMainInfo.Name}}</h1>
                <div class="form-group" *ngFor="let question of testMainInfo?.Questions_ChoosingAnswerFromList">
                  <p style="font-size:20px;">{{question?.QuestionText}}</p>
                  <div class="ui-g" style="width:250px;margin-bottom:10px">
                    <div class="ui-g-12" *ngFor="let answerVariant of question.AnswerVariants">
                      <p-radioButton
                        [name]="'group_' + testMainInfo.Id + '_' + question.SortKey"
                        [value]="answerVariant.Id"
                        [label]="answerVariant.AnswerText"
                        [inputId]="'opt_' + testMainInfo.Id + '_' + question.SortKey + '_' + answerVariant.SortKey"
                        [(ngModel)]="readerChoice_MainInfo.ReaderChoices_ChoosingAnswerFromList[question.SortKey].AnswerVariant_ChoosingAnswerFromList_Id">
                      </p-radioButton>
                    </div>
                  </div>
                </div>
                <button class="btn btn-default" style="background-color: rgb(220,220,220);" (click)="submit()">Отправить</button>
              </div>
              <h1>ResultTest: {{resultTest}}<h1>
            `,

  providers: [HttpService]
})
export class TestFormComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  resultTest: string;

  readerChoice_MainInfo: MReaderChoice_MainInfo;

  testMainInfo: MTest_MainInfo;

  ngOnInit() {

    this.httpService.getData()
      .subscribe((data: MTest_MainInfo) => this.testMainInfo = data);

    this.httpService.getResultTestStructure()
      .subscribe((data: MReaderChoice_MainInfo) => this.readerChoice_MainInfo = data);
  }

  submit()
  {
    this.httpService.postTestResult(this.readerChoice_MainInfo)
      .subscribe(
          (data: string) => {this.resultTest = data;},
          error => console.log(error)
      );
  }
}
