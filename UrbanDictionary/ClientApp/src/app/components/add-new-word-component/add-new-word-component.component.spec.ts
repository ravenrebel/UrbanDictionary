import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewWordComponentComponent } from './add-new-word-component.component';

describe('AddNewWordComponentComponent', () => {
  let component: AddNewWordComponentComponent;
  let fixture: ComponentFixture<AddNewWordComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNewWordComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNewWordComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
