import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WordComponentComponent } from './word-component.component';

describe('WordComponentComponent', () => {
  let component: WordComponentComponent;
  let fixture: ComponentFixture<WordComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WordComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WordComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
