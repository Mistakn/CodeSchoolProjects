function getUser() {

    let userID = document.getElementById('idInput').value;
    if (userID === 0) {
        return;
    }

    fetch(`https://jsonplaceholder.typicode.com/users/${userID}`)
        .then(response => response.json())
        .then(json => {
            console.log(`Name: ${json.name}. Email: ${json.email}.`);
            document.getElementById('userName').innerText = json.name;
            document.getElementById('userEmail').innerText = json.email;
        });
}