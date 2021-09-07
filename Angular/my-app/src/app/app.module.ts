import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatematicoComponent } from './matematico/matematico.component';
import { FormsModule } from '@angular/forms';
import { MatematicoResultComponent } from './matematico-result/matematico-result.component';

@NgModule({
  declarations: [
    AppComponent,
    MatematicoComponent,
    MatematicoResultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
