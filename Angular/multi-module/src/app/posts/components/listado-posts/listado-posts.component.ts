import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from '../../models/post.class';
import { PostsService } from '../../services/posts/posts.service';

@Component({
  selector: 'app-listado-posts',
  templateUrl: './listado-posts.component.html',
  styleUrls: ['./listado-posts.component.scss']
})
export class ListadoPostsComponent implements OnInit {


  public posts$: Observable<Post[]>;


  constructor(
    private postsService: PostsService
  ) { }


  ngOnInit(): void {
    this.getPosts();
  }


  private getPosts() {
    this.posts$ = this.postsService.getPosts();
  }
}
