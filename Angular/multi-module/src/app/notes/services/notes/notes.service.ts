import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler/error-handler.service';
import { Note } from '../../models/note.class';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  constructor(
    private httpClient: HttpClient,
    private errorHandlerService: ErrorHandlerService
  ) { }


  private readonly url = 'http://localhost:3000/notes';

  public getNotes(): Observable<Note[]> {
    return this.httpClient.get<Note[]>(this.url)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

  public getNote(noteId: string): Observable<Note> {
    return this.httpClient.get<Note>(`${ this.url }/${ noteId }`)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

  public createNote(note: Note): Observable<Note> {
    return this.httpClient.post<Note>(`${ this.url }`, note)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

  public updateNote(noteId: string, note: Note): Observable<Note> {
    return this.httpClient.put<Note>(`${ this.url }/${ noteId }`, note)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

  public deleteNote(noteId: string): Observable<unknown> {
    return this.httpClient.delete(`${ this.url }/${ noteId }`)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }
}
