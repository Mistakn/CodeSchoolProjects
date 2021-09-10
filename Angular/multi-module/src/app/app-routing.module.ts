import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListadoClientesComponent } from './clientes/listado-clientes/listado-clientes.component';
import { BuscarFacturaComponent } from './facturas/buscar-factura/buscar-factura.component';
import { ListadoFacturasComponent } from './facturas/listado-facturas/listado-facturas.component';
import { FormularioNoteComponent } from './notes/components/formulario-note/formulario-note.component';
import { ListadoNotesComponent } from './notes/components/listado-notes/listado-notes.component';
import { ListadoPostsComponent } from './posts/components/listado-posts/listado-posts.component';

const routes: Routes = [
  { path: 'listado-clientes', component: ListadoClientesComponent },
  { path: 'listado-facturas', component: ListadoFacturasComponent },
  { path: 'buscar-factura', component: BuscarFacturaComponent },
  { path: 'listado-posts', component: ListadoPostsComponent },
  { path: 'listado-notas', component: ListadoNotesComponent },
  { path: 'formulario-notas', component: FormularioNoteComponent },
  { path: 'formulario-notas/:idNote', component: FormularioNoteComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
