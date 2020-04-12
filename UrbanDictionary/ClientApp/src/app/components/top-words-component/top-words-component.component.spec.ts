import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopWordsComponentComponent } from './top-words-component.component';

describe('TopWordsComponentComponent', () => {
  let component: TopWordsComponentComponent;
  let fixture: ComponentFixture<TopWordsComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopWordsComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopWordsComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
