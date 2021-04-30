import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiabloiiComponent } from './diabloii.component';

describe('DiabloiiComponent', () => {
  let component: DiabloiiComponent;
  let fixture: ComponentFixture<DiabloiiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiabloiiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiabloiiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
