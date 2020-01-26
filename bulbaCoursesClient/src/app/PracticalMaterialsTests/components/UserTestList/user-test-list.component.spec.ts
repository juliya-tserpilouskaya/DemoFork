import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserTestListComponent } from './user-test-list.component';

describe('UserTestListComponent', () => {
  let component: UserTestListComponent;
  let fixture: ComponentFixture<UserTestListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserTestListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserTestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
