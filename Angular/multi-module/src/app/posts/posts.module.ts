import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListadoPostsComponent } from './components/listado-posts/listado-posts.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [ListadoPostsComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    ListadoPostsComponent
  ]
})
export class PostsModule { }
