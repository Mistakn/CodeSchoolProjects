import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListadoClientesComponent } from './listado-clientes/listado-clientes.component';



@NgModule({
  declarations: [
    ListadoClientesComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ListadoClientesComponent
  ]
})
export class ClientesModule { }
