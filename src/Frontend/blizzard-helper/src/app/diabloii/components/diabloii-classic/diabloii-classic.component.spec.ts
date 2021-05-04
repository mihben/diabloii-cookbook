import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiabloiiClassicComponent } from './diabloii-classic.component';

describe('DiabloiiClassicComponent', () => {
  let component: DiabloiiClassicComponent;
  let fixture: ComponentFixture<DiabloiiClassicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiabloiiClassicComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiabloiiClassicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
