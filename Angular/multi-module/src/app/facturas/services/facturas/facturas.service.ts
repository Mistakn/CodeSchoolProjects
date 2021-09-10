import { Injectable } from '@angular/core';
import { Factura } from '../../models/factura.class';

@Injectable({
  providedIn: 'root'
})
export class FacturasService {

  private facturas: Factura[] = [
    { id: 0, fecha: new Date(), clientId: 0, monto: 25 },
    { id: 1, fecha: new Date(), clientId: 1, monto: 50 },
    { id: 2, fecha: new Date(), clientId: 1, monto: 20 }
  ];

  constructor() { }

  public obtenerFacturas(): Factura[] {
    return this.facturas;
  }

  public agregarFactura(factura: Factura): void {
    this.facturas.push(factura);
  }

  public buscarFactura(id: number): Factura {
    return this.facturas.find(f => f.id == id);
  }
}
