import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListadoFacturasComponent } from './listado-facturas/listado-facturas.component';
import { FormsModule } from '@angular/forms';
import { BuscarFacturaComponent } from './buscar-factura/buscar-factura.component';



@NgModule({
  declarations: [
    ListadoFacturasComponent,
    BuscarFacturaComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    ListadoFacturasComponent
  ]
})
export class FacturasModule { }
