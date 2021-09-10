import { Component, OnInit } from '@angular/core';

type Operations = 'Suma' | 'Resta' | 'Multiplicacion' | 'Division';

@Component({
  selector: 'app-matematico',
  templateUrl: './matematico.component.html',
  styleUrls: ['./matematico.component.scss']
})
export class MatematicoComponent implements OnInit {


  public numero1: number = 0;
  public numero2: number = 0;
  public resultado: number = 0;
  public operacionARealizar: Operations = 'Suma';
  public operaciones: Operations[] = ['Suma', 'Resta', 'Multiplicacion', 'Division'];
  public today: Date = new Date();

  constructor() { }

  ngOnInit(): void {
  }


  public calculate() {

    if (!this.numero1 || !this.numero2)
      return;

    switch (this.operacionARealizar) {
      case 'Suma':
        this.resultado = this.numero1 + this.numero2;
        break;

      case 'Resta':
        this.resultado = this.numero1 - this.numero2;
        break;

      case 'Multiplicacion':
        this.resultado = this.numero1 * this.numero2;
        break;

      case 'Division':
        this.resultado = this.numero1 / this.numero2;
        break;
    }
  }


  public limpiarCampos() {
    this.numero1 = 0;
    this.numero2 = 0;
    this.resultado = 0;
    this.operacionARealizar = 'Suma';
  }
}
