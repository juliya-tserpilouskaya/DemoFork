import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http-test-client.service';
import { MTest_MainInfo } from '../../models/test/Test/MTest_MainInfo';
import { MReaderChoice_MainInfo } from '../../models/WorkWithResultTest/MReaderChoice_MainInfo';

@Component({
  selector: 'app-test-form',
  template:  `<div>
                <div class="form-group" *ngFor="let question of testMainInfo?.Questions_ChoosingAnswerFromList">
                  <div class="ui-g" style="width:250px;margin-bottom:10px">
                    <p>Текст вопроса: {{question?.QuestionText}}</p>
                    <div class="ui-g-12" *ngFor="let answerVariant of question.AnswerVariants">
                      <p-radioButton
                        [name]="'group_' + testMainInfo.Id + '_' + question.SortKey"
                        [value]="answerVariant.SortKey"
                        [label]="answerVariant.AnswerText"
                        [inputId]="'opt_' + testMainInfo.Id + '_' + question.SortKey + '_' + answerVariant.SortKey"
                        [(ngModel)]="items[question.SortKey]"
                      >
                      </p-radioButton>
                    </div>
                  </div>
                </div>
              </div>
              Selected Value = {{items[0]||'none'}}
              Selected Value = {{items[1]||'none'}}
              Selected Value = {{items[2]||'none'}}
            `,

  providers: [HttpService]
})
export class TestFormComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  items = [];

  readerChoice_MainInfo: MReaderChoice_MainInfo;

  testMainInfo: MTest_MainInfo;

  ngOnInit() {
    this.httpService.getData().subscribe((data: MTest_MainInfo) => this.testMainInfo = data);
  }
}
