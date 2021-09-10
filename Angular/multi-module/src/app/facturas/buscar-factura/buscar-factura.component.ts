import { Component, OnInit } from '@angular/core';
import { Factura } from '../models/factura.class';
import { FacturasService } from '../services/facturas/facturas.service';

@Component({
  selector: 'app-buscar-factura',
  templateUrl: './buscar-factura.component.html',
  styleUrls: ['./buscar-factura.component.scss']
})
export class BuscarFacturaComponent implements OnInit {

  public idFacturaABuscar: string;
  public facturaBuscada: Factura;

  constructor(
    private facturasService: FacturasService
  ) { }

  ngOnInit(): void {
  }

  public buscarFactura() {
    this.facturaBuscada = this.facturasService.buscarFactura(parseInt(this.idFacturaABuscar, 10));
  }
}
