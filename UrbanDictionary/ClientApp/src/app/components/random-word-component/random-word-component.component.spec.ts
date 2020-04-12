import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RandomWordComponentComponent } from './random-word-component.component';

describe('RandomWordComponentComponent', () => {
  let component: RandomWordComponentComponent;
  let fixture: ComponentFixture<RandomWordComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RandomWordComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RandomWordComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
