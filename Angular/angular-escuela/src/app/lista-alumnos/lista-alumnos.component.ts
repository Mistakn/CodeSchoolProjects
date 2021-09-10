import { CursorError } from '@angular/compiler/src/ml_parser/lexer';
import { Component, OnInit } from '@angular/core';
import { Alumno } from '../classes/alumno.class';

@Component({
  selector: 'app-lista-alumnos',
  templateUrl: './lista-alumnos.component.html',
  styleUrls: ['./lista-alumnos.component.scss']
})
export class ListaAlumnosComponent implements OnInit {

  public alumnos: Alumno[] = [
    {
      nombre: 'Cuit',
      apellidos: 'Rodriguez',
      correo: 'cuit@correo.com',
      fechaIngreso: new Date()
    },
    {
      nombre: 'Cuitlahuac',
      apellidos: 'Rodriguez',
      correo: 'cuitlahuac@correo.com',
      fechaIngreso: new Date()
    },
    {
      nombre: 'Tahua',
      apellidos: 'Rodriguez',
      correo: 'tahua@correo.com',
      fechaIngreso: new Date()
    }
  ];
  public displayType: 'Table' | 'List' = 'Table';

  constructor() { }

  ngOnInit(): void {
  }

}
