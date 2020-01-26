import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVideoProfComponent } from './add-video-prof.component';

describe('AddVideoProfComponent', () => {
  let component: AddVideoProfComponent;
  let fixture: ComponentFixture<AddVideoProfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddVideoProfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddVideoProfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
