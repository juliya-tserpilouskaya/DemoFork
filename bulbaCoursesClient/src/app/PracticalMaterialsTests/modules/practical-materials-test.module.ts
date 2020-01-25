import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TabViewModule } from 'primeng/tabview';
import { TestFormComponent } from '../components/test-form.component';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    TabViewModule
  ],
  declarations: [TestFormComponent],
  bootstrap: [TestFormComponent]
})
export class PracticalMaterialsTestModule { }
