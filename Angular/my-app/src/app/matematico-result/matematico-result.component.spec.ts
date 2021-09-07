import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatematicoResultComponent } from './matematico-result.component';

describe('MatematicoResultComponent', () => {
  let component: MatematicoResultComponent;
  let fixture: ComponentFixture<MatematicoResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MatematicoResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MatematicoResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
