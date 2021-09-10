import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioNoteComponent } from './formulario-note.component';

describe('FormularioNoteComponent', () => {
  let component: FormularioNoteComponent;
  let fixture: ComponentFixture<FormularioNoteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormularioNoteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioNoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
