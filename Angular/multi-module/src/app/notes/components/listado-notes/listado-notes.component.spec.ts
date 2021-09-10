import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoNotesComponent } from './listado-notes.component';

describe('ListadoNotesComponent', () => {
  let component: ListadoNotesComponent;
  let fixture: ComponentFixture<ListadoNotesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListadoNotesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListadoNotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
