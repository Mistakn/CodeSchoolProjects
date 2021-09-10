import { Component, EventEmitter, OnChanges, OnDestroy, OnInit, Output, SimpleChanges } from '@angular/core';
import { Producto } from '../models/producto.model';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.scss']
})
export class NewProductComponent implements OnInit, OnDestroy, OnChanges {

  public nombreProducto: string = '';
  public precioProducto: string = '';

  @Output()
  eventoAgregarProducto = new EventEmitter();


  constructor() { }


  ngOnInit(): void {
    console.log('Agregar producto inicializado');
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log('Agregar producto cambio');
  }

  ngOnDestroy(): void {
    console.log('Agregar producto destruido');
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
