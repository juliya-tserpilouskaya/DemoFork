import { Component, OnInit, Input } from '@angular/core';
import { SearchService, Courses } from '../../services/search.service';
import { Validators, FormGroup, FormArray, FormBuilder } from '@angular/forms';
import { HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';
import { HttpCourseService } from '../../services/httpcourse.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent {

  query: string = "";
  public isCollapsed = true;
  public myForm: FormGroup;
  model: Course;
  receivedString: string;
  done: boolean = false;

  constructor(private _fb: FormBuilder, private client: HttpClient, private service: HttpCourseService) {
    this.myForm = this._fb.group({
      Name: ['', [Validators.required, Validators.minLength(5)]],
      Description: ['', [Validators.required, Validators.minLength(10)]],
      Cost: ['', [Validators.required]],
      Complexity: [''],
      Language: [''],
      Items: this._fb.array([
          this.initItem(),
      ])
  });
  }

  getFormData()
  {
    return this.myForm.get('Items');
  }


  initItem() {
    return this._fb.group({
        Name: ['', [Validators.required, Validators.minLength(5)]],
        Description: ['', [Validators.required, Validators.minLength(10)]]
    });
  }

  addItem() {
    const control = <FormArray>this.myForm.controls['Items'];
    control.push(this.initItem());
  }

  removeItem(i: number) {
    const control = <FormArray>this.myForm.controls['Items'];
    control.removeAt(i);
  }

  save(model: Course) {
    // this.model = model;

    let formObj = this.myForm.getRawValue();
    formObj.AuthorId = 1;
    formObj.Category = 1;
    var body = JSON.stringify(formObj);

    this.service.postData(body)
    .subscribe(
        (data: string) => {this.receivedString = data; this.done = true; },
        error => console.log(error),
        () => console.log('Observer got a complete notification')
    );
  }
}


export interface Course {
  Name: string;
  Description: string;
  Cost: number;
  Complexity: string;
  Language: string;
  Items: Items[];
  AuthorId: number;
  Category: number;
}

export interface Items {
  name: string;
  description: string;
}
