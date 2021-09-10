import { Component, EventEmitter, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Producto } from '../models/producto.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit, OnChanges {

  public productos: Producto[] = []
  public total: number = 0;

  @Output()
  eventoFinalizarOrden = new EventEmitter();

  constructor() { }


  ngOnInit(): void {
    console.log('Listado producto inicializado');
  }

  ngOnChanges(changes: SimpleChanges): void {
    for (const propiedad in changes) {
      if (Object.prototype.hasOwnProperty.call(changes, propiedad)) {
        const element = changes[propiedad];
        console.log(element);
      }
    }
  }

  public agregarProducto(producto: Producto) {
    this.productos.push(producto);
    this.total += producto.precio;
  }
}
