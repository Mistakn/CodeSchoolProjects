class Polygon {
    constructor(base, height) {
        this.base = base;
        this.height = height;
    }
}

class Triangle extends Polygon {
    getArea = () => {
        return (this.base * this.height) / 2
    }
}

class Square extends Polygon {
    constructor(side) {
        super(side, side);
    }

    getArea = () => {
        return (this.base * this.base);
    }
}

class Rectangle extends Polygon {
    getArea = () => {
        return this.base * this.height;
    }
}


let triangle = new Triangle(3, 5);
let square = new Square(4);
let rectangle = new Rectangle(5, 6);

console.log(`Triangle area: ${triangle.getArea()}`);
console.log(`Square area: ${square.getArea()}`);
console.log(`Rectangle area: ${rectangle.getArea()}`);