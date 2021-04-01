import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RuneWordComponent } from './rune-word.component';

describe('RuneWordComponent', () => {
  let component: RuneWordComponent;
  let fixture: ComponentFixture<RuneWordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RuneWordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RuneWordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
