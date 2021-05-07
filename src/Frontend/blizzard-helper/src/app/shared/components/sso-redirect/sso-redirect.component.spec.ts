import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SsoRedirectComponent } from './sso-redirect.component';

describe('SsoRedirectComponent', () => {
  let component: SsoRedirectComponent;
  let fixture: ComponentFixture<SsoRedirectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SsoRedirectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SsoRedirectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
