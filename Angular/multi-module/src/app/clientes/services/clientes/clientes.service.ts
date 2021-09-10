import { Injectable } from '@angular/core';
import { Cliente } from 'src/app/clientes/models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {


  constructor() { }


  public getClientes(): Cliente[] {
    return [
      { nombre: 'Cuit Rodriguez', email: 'cuit@email.com' },
      { nombre: 'Cuitlahuac Rodriguez', email: 'cuitlahuac@email.com' },
      { nombre: 'Tahua Rodriguez', email: 'tahua@email.com' },
    ];
  }

}
