let myBoolean: boolean = true;
let myNumber: number = 123;
let myStringArray: string[] = ['first', 'second'];
let flag: boolean = false;
let dato: any = 'Dato cadena';
console.log(dato);
dato = 1000;
console.log(dato);
dato = true;
console.log(dato);
type Animal = 'Cheetah' | 'Lion';
let animal: Animal = 'Cheetah';
enum Brands { Chevrolet, Cadillac, Ford, Buick, Chrysler, Dodge };
const myCar: Brands = Brands.Cadillac;

function SaludarUsuario(): void {
    console.log('Hola usuario');
}

let marca = 'Bachoco';

function SumaDeNumeros(num1: number, num2: number): number;
function SumaDeNumeros(num1: number[]): number;
function SumaDeNumeros(num1: any, num2?: number): number {
    let suma = 0;
    if (Array.isArray(num1)) {

    }
    return suma;
}

function hello(names: string): string;
function hello(names: string[]): string;
function hello(names: any, greeting?: string): string {
    let namesArray: string[];
    if (Array.isArray(names)) {
        namesArray = names;
    } else {
        namesArray = [names];
    }
    if (!greeting) {
        greeting = 'Hello';
    }
    return greeting + ', ' + namesArray.join(' and ') + '!';
}

class Persona {
    private nombre: string = '';
    private apellidoPaterno: string = '';
    private apellidoMaterno: string = '';

    constructor(nombre: string, apellidoPaterno: string, apellidoMaterno: string, private mayorDeEdad: boolean) {
        this.nombre = nombre;
        this.apellidoPaterno = apellidoPaterno;
        this.apellidoMaterno = apellidoMaterno;
    }

    getINE(): string {
        return this.mayorDeEdad ? 'Puede tramitar INE' : 'No puede tramitar INE';
    }
}


interface FiguraGeometrica {
    color: string;
    base: number;
    altura: number;
    diametro?: number;

    calcularArea(): number;
}


class Rectangulo implements FiguraGeometrica {
    color: string;
    base: number;
    altura: number;

    constructor(color: string, base: number, altura: number) {
        this.color = color;
        this.base = base;
        this.altura = altura;
    }

    calcularArea(): number {
        return this.base * this.altura;
    }
}

class Circulo implements FiguraGeometrica {
    color: string;
    base: number;
    altura: number;
    diametro: number;

    constructor(color: string, base: number, altura: number, diametro: number) {
        this.color = color;
        this.base = base;
        this.altura = altura;
        this.diametro = diametro;
    }

    calcularArea(): number {
        return Math.PI * Math.pow(this.diametro, 2);
    }
}

class Triangulo implements FiguraGeometrica {
    color: string;
    base: number;
    altura: number;

    constructor(color: string, base: number, altura: number) {
        this.color = color;
        this.base = base;
        this.altura = altura;
    }

    calcularArea(): number {
        return (this.base * this.altura) / 2;
    }
}

class TrianguloIsosceles extends Triangulo { }

class TrianguloEscaleno extends Triangulo { }

let miTriangulo = new TrianguloEscaleno('rojo', 5, 6);
miTriangulo.color = 'azul';
miTriangulo.calcularArea();