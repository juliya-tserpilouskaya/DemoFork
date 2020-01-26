import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http-test-client.service';
import { MTest_MainInfo } from '../../models/test/Test/MTest_MainInfo';
import { MReaderChoice_MainInfo } from '../../models/WorkWithResultTest/MReaderChoice_MainInfo';

@Component({
  selector: 'app-test-form',
  template:  `<div>
                <div class="form-group" *ngFor="let question of testMainInfo?.Questions_ChoosingAnswerFromList">
                  <p>Текст вопроса: {{question?.QuestionText}}</p>
                  <div class="ui-g" style="width:250px;margin-bottom:10px">
                    <div class="ui-g-12" *ngFor="let answerVariant of question.AnswerVariants">
                      <p-radioButton
                        [name]="'group_' + testMainInfo.Id + '_' + question.SortKey"
                        [value]="answerVariant.Id"
                        [label]="answerVariant.AnswerText"
                        [inputId]="'opt_' + testMainInfo.Id + '_' + question.SortKey + '_' + answerVariant.SortKey"
                        [(ngModel)]="readerChoice_MainInfo.ReaderChoices_ChoosingAnswerFromList[question.SortKey].AnswerVariant_ChoosingAnswerFromList_Id"
                      >
                      </p-radioButton>
                    </div>
                  </div>
                </div>
                <button class="btn btn-default" (click)="submit()">Отправить</button>
              </div>
              Selected Value = {{resultTest||'none'}}
            `,

  providers: [HttpService]
})
export class TestFormComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  done: boolean = false;

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
          (data: string) => {this.resultTest=data; this.done=true;},
          error => console.log(error)
      );
  }
}
