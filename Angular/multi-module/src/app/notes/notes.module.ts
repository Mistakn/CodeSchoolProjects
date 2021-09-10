import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListadoNotesComponent } from './components/listado-notes/listado-notes.component';
import { FormsModule } from '@angular/forms';
import { FormularioNoteComponent } from './components/formulario-note/formulario-note.component';



@NgModule({
  declarations: [ListadoNotesComponent, FormularioNoteComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    ListadoNotesComponent
  ]
})
export class NotesModule { }
