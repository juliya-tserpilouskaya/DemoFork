import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SampleService } from './services/sample.service';
import { SampleComponent } from './components/sample/sample.component';

@NgModule({
  declarations: [SampleComponent],
  imports: [
    CommonModule
  ],
  providers: [SampleService],
  exports: [SampleComponent]
})
export class SampleModule { }
