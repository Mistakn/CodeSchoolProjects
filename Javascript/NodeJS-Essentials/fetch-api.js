fetch('https://jsonplaceholder.typicode.com/users')
    .then(response => response.jason())
    .then(json => console.log(json));

fetch('https://jsonplaceholder.typicode.com/users', {
    method: 'POST',
    body: JSON.stringify({
        title: 'foo',
        body: 'bar',
        userId: 1,
    }),
    headers: {
        'Content-type': 'application/json; charset=UTF-8',
    },
})
    .then(response => response.json())
    .then(json => console.log(json));


async function getUser(id) {
    let response = await fetch(`https://jsonplaceholder.typicode.com/users/${id}`);
    let data = await response.json();
    return data;
}

getUser(1).then(userData => { console.log(userData) });