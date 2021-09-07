enum Roles { Admin, User, SuperUser };

function suma(num1: number, num2: number): number {
    return num1 + num2;
}

function resta(num1: number, num2: number): number {
    return num1 - num2;
}

function multiplicacion(num1: number, num2: number): number {
    return num1 * num2;
}

function division(num1: number, num2: number): number {
    return num1 / num2;
}

function agregaUsuario(nombre: string, rol: Roles): void {
    console.log('Usuario registrado');
}

const mayorDeDosNumeros = (num1: number, num2: number): number => num1 > num2 ? num1 : num2;

