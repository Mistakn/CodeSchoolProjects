'use strict'
let myBoolean = true;
let myNumber = 123;
let myStringArray = ['first', 'second'];
let flag = false;
let dato = 'Dato cadena';
console.log(dato);
dato = 1000;
console.log(dato);
dato = true;
console.log(dato);
const prueba = 'Lion';

class Persona {

    constructor(nombre, apellidoPaterno, apellidoMaterno, mayorDeEdad) {
        this.nombre = nombre;
        this.apellidoPaterno = apellidoPaterno;
        this.apellidoMaterno = apellidoMaterno;
        this.mayorDeEdad = mayorDeEdad;
    }

    getINE() {
        return this.mayorDeEdad ? 'Puede tramitar INE' : 'No puede tramitar INE';
    }
}