function getUser() {

    let userID = document.getElementById('idInput').value;
    if (userID === 0) {
        return;
    }

    $.ajax({
        url: `https://jsonplaceholder.typicode.com/users/${userID}`,
        contentType: "application/json",
        dataType: 'json',
        type: 'get',
        success: function (result) {
            console.log(`Name: ${result.name}. Email: ${result.email}.`);
            document.getElementById('userName').innerText = result.name;
            document.getElementById('userEmail').innerText = result.email;
        },
        failure: function (result) {
            console.log('Something went wrong');
        }
    });
}