import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Producto } from '../models/producto.model';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.scss']
})
export class NewProductComponent implements OnInit {

  public nombreProducto: string = '';
  public precioProducto: string = '';

  @Output()
  eventoAgregarProducto = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }


  public agregarProducto() {
    let producto: Producto = {
      nombre: this.nombreProducto,
      precio: parseInt(this.precioProducto, 10)
    };

    this.eventoAgregarProducto.emit(producto);

    this.nombreProducto = '';
    this.precioProducto = '';
  }
}
