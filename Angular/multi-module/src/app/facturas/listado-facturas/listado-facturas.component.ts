import { Component, OnInit } from '@angular/core';
import { Factura } from '../models/factura.class';
import { FacturasService } from '../services/facturas/facturas.service';

@Component({
  selector: 'app-listado-facturas',
  templateUrl: './listado-facturas.component.html',
  styleUrls: ['./listado-facturas.component.scss']
})
export class ListadoFacturasComponent implements OnInit {

  public facturas: Factura[];

  constructor(
    private facturasService: FacturasService
  ) { }

  ngOnInit(): void {
    let facturaAAgregar: Factura = { id: 3, fecha: new Date(), clientId: 2, monto: 15 };
    this.facturasService.agregarFactura(facturaAAgregar);

    this.facturas = this.facturasService.obtenerFacturas();
  }

}
