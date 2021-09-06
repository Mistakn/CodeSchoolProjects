import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EncabezadoComponent } from './encabezado/encabezado.component';
import { AvisosComponent } from './avisos/avisos.component';
import { ContenidoPrincipalComponent } from './contenido-principal/contenido-principal.component';
import { MenuLateralComponent } from './menu-lateral/menu-lateral.component';
import { PiePaginaComponent } from './pie-pagina/pie-pagina.component';

@NgModule({
  declarations: [
    AppComponent,
    EncabezadoComponent,
    AvisosComponent,
    ContenidoPrincipalComponent,
    MenuLateralComponent,
    PiePaginaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
