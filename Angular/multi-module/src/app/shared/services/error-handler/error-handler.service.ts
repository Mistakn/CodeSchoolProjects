import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  constructor() { }


  public handleError(error: HttpErrorResponse) {

    let message: string = 'Unkown error';

    if (error.error instanceof ErrorEvent) { // Client-side error
      message = `Error: ${ error.error.message }`;
    } else { // Server-side error
      message = `Error: ${ error.status } ${ error.message }`;
    }

    return throwError(error);
  }
}
