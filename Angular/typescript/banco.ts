interface ICuenta {
    saldo: number;

    deposito(cantidad: number): void;
    retiro(cantidad: number): void;
    consultarSaldo(): number;
}

interface ICuentaDeCredito extends ICuenta {
    saldo: number;

    deposito(cantidad: number): void;
    retiro(cantidad: number): void;
    consultarSaldo(): number;
    calcularIntereses(): number;
}


class CuentaPersonal implements ICuenta {
    saldo: number;


    constructor(saldoInicial: number) {
        this.saldo = saldoInicial;
    }


    deposito(cantidad: number): void {
        this.saldo += cantidad;
    }
    retiro(cantidad: number): void {
        if (cantidad <= this.saldo) {
            this.saldo -= cantidad;
        }
    }
    consultarSaldo(): number {
        return this.saldo;
    }

}

class CuentaEmpresarial implements ICuenta {
    saldo: number;


    constructor(saldoInicial: number) {
        this.saldo = saldoInicial;
    }


    deposito(cantidad: number): void {
        this.saldo += cantidad;
    }
    retiro(cantidad: number): void {
        if (cantidad <= this.saldo) {
            this.saldo -= cantidad;
        }
    }
    consultarSaldo(): number {
        return this.saldo;
    }

}

class TarjetaDeCredito implements ICuentaDeCredito {
    saldo: number;


    constructor(saldoInicial: number) {
        this.saldo = saldoInicial;
    }


    calcularIntereses(): number {
        throw new Error("Method not implemented.");
    }
    deposito(cantidad: number): void {
        this.saldo += cantidad;
    }
    retiro(cantidad: number): void {
        if (cantidad <= this.saldo) {
            this.saldo -= cantidad;
        }
    }
    consultarSaldo(): number {
        return this.saldo;
    }

}


var cuentaPersonal = new CuentaPersonal(500);
cuentaPersonal.consultarSaldo();
cuentaPersonal.retiro(200);
cuentaPersonal.deposito(600);

var cuentaEmpresarial = new CuentaEmpresarial(500);
cuentaEmpresarial.consultarSaldo();
cuentaEmpresarial.retiro(200);
cuentaEmpresarial.deposito(600);

var tarjetaDeCredito = new TarjetaDeCredito(5000);
tarjetaDeCredito.consultarSaldo();
tarjetaDeCredito.retiro(200);
tarjetaDeCredito.deposito(600);
tarjetaDeCredito.calcularIntereses();