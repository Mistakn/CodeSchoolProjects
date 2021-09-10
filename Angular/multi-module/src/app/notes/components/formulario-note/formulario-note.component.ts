import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Note } from '../../models/note.class';
import { NotesService } from '../../services/notes/notes.service';

@Component({
  selector: 'app-formulario-note',
  templateUrl: './formulario-note.component.html',
  styleUrls: ['./formulario-note.component.scss']
})
export class FormularioNoteComponent implements OnInit {

  public title: string;
  public content: string;
  public idNoteToUpdate: string;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private notesService: NotesService
  ) {
    this.idNoteToUpdate = this.activatedRoute.snapshot.params.idNote ? activatedRoute.snapshot.params.idNote : '';
  }

  async ngOnInit(): Promise<void> {
    if (this.idNoteToUpdate) {
      let noteData = await this.notesService.getNote(this.idNoteToUpdate).toPromise();
      this.title = noteData.title;
      this.content = noteData.content;
    }
  }


  public async saveNote() {
    if (this.title.trim() == '' || this.content.trim() == '')
      return;

    let note: Note = this.generateDTO();

    if (this.idNoteToUpdate) {
      await this.notesService.updateNote(this.idNoteToUpdate, note).toPromise();
    } else {
      await this.notesService.createNote(note).toPromise();
    }

    this.goToNotes();
  }

  public goToNotes() {
    this.router.navigate(['/listado-notas']);
  }

  private generateDTO(): Note {
    return {
      title: this.title,
      content: this.content
    };
  }

}
