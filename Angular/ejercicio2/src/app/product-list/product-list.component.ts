import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Producto } from '../models/producto.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  public productos: Producto[] = []
  public total: number = 0;

  @Output()
  eventoFinalizarOrden = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  public agregarProducto(producto: Producto) {
    this.productos.push(producto);
    this.total += producto.precio;
  }
}
