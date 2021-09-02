class Person {
    constructor(name, fathersLastName, mothersLastName, email) {
        this.name = name;
        this.fathersLastName = fathersLastName;
        this.mothersLastName = mothersLastName;
        this.email = email;
    }

    printPerson = () => {
        console.log(this);
    }
}

let person1 = new Person('Cuit', 'Rodriguez', 'Villavicencio', 'cuit@email.com');
persona1.printPerson();

console.log(JSON.stringify(person1));


let person2 = new Person('Cuitlahuac', 'Rodriguez', 'Villavicencio', 'cuit@email.com');
persona2.printPerson();

console.log(JSON.stringify(person2));


let person3 = new Person('Mario', 'Mario', 'Bros', 'mario@email.com');
persona3.printPerson();

console.log(JSON.stringify(person3));


let people = [];
people.push(person1);
people.push(person2);
people.push(person3);

console.log(JSON.stringify(people));