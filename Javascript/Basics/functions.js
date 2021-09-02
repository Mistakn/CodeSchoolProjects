function addNumbers(num1, num2) {
    return num1 + num2;
}

function subtractNumbers(num1, num2) {
    return num1 - num2;
}

function findCharacter(haystack, needle) {
    // return haystack.toLowerCase().includes(needle.toLowerCase());

    var found = false;

    for (let i = 0; i < haystack.length; i++) {

        let currentLetter = haystack[i];
        found = currentLetter.toLowerCase() == needle.toLowerCase()

        if (found) {
            break;
        }
    }

    return found;
}