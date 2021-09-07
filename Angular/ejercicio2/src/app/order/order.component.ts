import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public finalizarOrden(total: number) {
    alert('Orden finalizada exitosamente, el costo total de la orden es de $' + total.toFixed(2));
  }
}
