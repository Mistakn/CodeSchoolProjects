import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler/error-handler.service';
import { Post } from '../../models/post.class';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(
    private httpClient: HttpClient,
    private errorHandlerService: ErrorHandlerService
  ) { }


  private readonly url = 'https://jsonplaceholder.typicode.com/posts';

  public getPosts(): Observable<Post[]> {
    return this.httpClient.get<Post[]>(this.url)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

  public getPost(postId: number): Observable<Post> {
    return this.httpClient.get<Post>(`${ this.url }/${ postId }`)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

  public createPost(post: Post): Observable<Post> {
    return this.httpClient.post<Post>(`${ this.url }`, post)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

  public updatePost(post: Post): Observable<Post> {
    return this.httpClient.put<Post>(`${ this.url }`, post)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

  public deletePost(postId: number): Observable<unknown> {
    return this.httpClient.delete(`${ this.url }/${ postId }`)
      .pipe(
        catchError((err) => {
          return this.errorHandlerService.handleError(err);
        })
      );
  }

}

