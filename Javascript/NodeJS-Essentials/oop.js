class Animal {
    constructor(category) {
        this.category = category;
    }
}


class BankAccount {

    #privateField = 0;

    constructor(balance) {
        this.balance = balance;
    }


    getPrivateField() {
        return this.#privateField;
    }


    deposit = (amount) => {
        this.balance += amount;
    }

    withdrawal = (amount) => {
        if (amount < this.balance) {
            this.balance -= amount;
        }
    }
}


class CreditCard extends BankAccount {
    constructor(balance, cutoffDate, minimumPayment) {
        super(balance);
        this.cutoffDate = cutoffDate;
        this.minimumPayment = minimumPayment;
    }

    getCutoffDate = () => {
        return this.cutoffDate;
    }

    getMinimumPayment = () => {
        return this.minimumPayment;
    }
}


var main = () => {
    let dog = new Animal('Dog');
    let cat = new Animal('Cat');

    console.log(dog.category);
    console.log(cat.category);


    let bankAccount = new BankAccount(5000);
    bankAccount.deposit(200);
    bankAccount.deposit(800);

    console.log(bankAccount.balance);


    let creditCard = new CreditCard(3000, '01/01/21', 500);

    console.log(creditCard.getCutoffDate());
    console.log(creditCard.getMinimumPayment());
}


main();