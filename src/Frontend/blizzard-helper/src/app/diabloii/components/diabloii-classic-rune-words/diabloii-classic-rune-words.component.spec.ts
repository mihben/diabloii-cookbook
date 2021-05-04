import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiabloiiClassicRuneWordsComponent } from './diabloii-classic-rune-words.component';

describe('DiabloiiClassicRuneWordsComponent', () => {
  let component: DiabloiiClassicRuneWordsComponent;
  let fixture: ComponentFixture<DiabloiiClassicRuneWordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiabloiiClassicRuneWordsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiabloiiClassicRuneWordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
