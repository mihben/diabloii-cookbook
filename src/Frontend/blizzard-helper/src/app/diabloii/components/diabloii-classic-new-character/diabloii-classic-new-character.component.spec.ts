import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiabloiiClassicNewCharacterComponent } from './diabloii-classic-new-character.component';

describe('DiabloiiClassicNewCharacterComponent', () => {
  let component: DiabloiiClassicNewCharacterComponent;
  let fixture: ComponentFixture<DiabloiiClassicNewCharacterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiabloiiClassicNewCharacterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiabloiiClassicNewCharacterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
