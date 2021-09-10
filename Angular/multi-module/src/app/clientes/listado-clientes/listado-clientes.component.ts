import { Component, OnInit } from '@angular/core';

// Classes
import { Cliente } from 'src/app/clientes/models/cliente';
import { ClientesService } from '../services/clientes/clientes.service';

@Component({
  selector: 'app-listado-clientes',
  templateUrl: './listado-clientes.component.html',
  styleUrls: ['./listado-clientes.component.scss']
})
export class ListadoClientesComponent implements OnInit {

  public clientes: Cliente[];

  constructor(
    private clientesService: ClientesService
  ) { }

  ngOnInit(): void {
    this.clientes = this.clientesService.getClientes();
  }

}