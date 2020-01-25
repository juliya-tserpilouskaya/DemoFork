import { Component, OnInit, Input } from '@angular/core';
import { SearchService, Courses } from '../../services/search.service';
import { Validators, FormGroup, FormArray, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent {

  query: string = "";
  public isCollapsed = false;
  public myForm: FormGroup;

  constructor(private _fb: FormBuilder) {
    this.myForm = this._fb.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
      description: [''],
      price: [''],
      complexity: [''],
      language: [''],
      items: this._fb.array([
          this.initItem(),
      ])
  });
  }

  initItem() {
    return this._fb.group({
        name: ['', Validators.required],
        description: ['']
    });
  }

  addItem() {
    const control = <FormArray>this.myForm.controls['items'];
    control.push(this.initItem());
  }

  removeItem(i: number) {
    // remove address from the list
    const control = <FormArray>this.myForm.controls['items'];
    control.removeAt(i);
  }

  save(model: Course) {
    // call API to save customer
    console.log(model);
  }
}

export interface Course {
  name: string;
  description: string;
  price: number;
  complexity: string;
  language: string;
  items: Items[];
}

export interface Items {
  name: string;
  description: string;
}
