import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-matematico-result',
  templateUrl: './matematico-result.component.html',
  styleUrls: ['./matematico-result.component.scss']
})
export class MatematicoResultComponent implements OnInit {

  @Input()
  result: number;

  @Output()
  eventoLimpiarCampos = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }
}
