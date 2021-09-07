import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatematicoComponent } from './matematico.component';

describe('MatematicoComponent', () => {
  let component: MatematicoComponent;
  let fixture: ComponentFixture<MatematicoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MatematicoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MatematicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
