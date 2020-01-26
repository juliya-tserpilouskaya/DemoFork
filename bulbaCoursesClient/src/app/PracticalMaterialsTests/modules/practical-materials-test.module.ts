import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TabViewModule } from 'primeng/tabview';
import { FormsModule } from '@angular/forms';
import { TestMainFormComponent } from '../components/MainForm/test-main-form.component';
import { UserTestListComponent } from '../components/UserTestList/user-test-list.component';
import { TestFormComponent } from '../components/TestForm/test-form.component';
import { RadioButtonModule } from 'primeng/radiobutton';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    TabViewModule,
    FormsModule,
    RadioButtonModule
  ],
  declarations: [TestFormComponent, UserTestListComponent],
  bootstrap: [TestFormComponent]
})
export class PracticalMaterialsTestModule { }
