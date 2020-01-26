import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestMainFormComponent } from './test-main-form.component';

describe('TestMainFormComponent', () => {
  let component: TestMainFormComponent;
  let fixture: ComponentFixture<TestMainFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestMainFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestMainFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
