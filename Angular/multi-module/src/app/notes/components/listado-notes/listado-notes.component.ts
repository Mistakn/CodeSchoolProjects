import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Note } from '../../models/note.class';
import { NotesService } from '../../services/notes/notes.service';

@Component({
  selector: 'app-listado-notes',
  templateUrl: './listado-notes.component.html',
  styleUrls: ['./listado-notes.component.scss']
})
export class ListadoNotesComponent implements OnInit {

  public notes: Note[];
  public title: string;
  public content: string;
  public idNoteToUpdate: string;


  constructor(
    private notesService: NotesService,
    private router: Router
  ) { }


  ngOnInit(): void {
    this.getNotes();
  }


  public startUpdate(note: Note) {
    this.router.navigate([`/formulario-notas/${ note._id }`]);
  }

  public async deleteNote(idNoteToUpdate: string) {
    if (idNoteToUpdate.trim() == '')
      return;

    await this.notesService.deleteNote(idNoteToUpdate).toPromise();
    await this.getNotes();
  }


  private async getNotes() {
    this.notes = await this.notesService.getNotes().toPromise();
  }


}
