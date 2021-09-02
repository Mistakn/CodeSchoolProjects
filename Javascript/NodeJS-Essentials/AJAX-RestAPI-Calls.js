$(document).ready(function () {
    let endpoint = 'https://api.linkpreview.net'
    let apiKey = '5b578yg9yvi8sogirbvegoiufg9v9g579gviuiub8'

    $.ajax({
        url: 'https://jsonplaceholder.typicode.com/posts/30',
        contentType: "application/json",
        dataType: 'json',
        type: 'get',
        success: function (result) {
            console.log(result.title);
        },
        failure: function (result) {
            console.log('Something went wrong');
        }
    })
});
