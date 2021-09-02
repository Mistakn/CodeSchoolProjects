// Set up our HTTP request
var xhr = new XMLHttpRequest();

// Setup our listener to process completed requests
xhr.onload = function () {

    // Process our return data
    if (xhr.status >= 200 && xhr.status < 300) {
        // What do when the request is successful
        // console.log('success!', xhr);
        JSON.parse(xhr.response).forEach(post => {
            // console.log(`Title: ${post.title} Body: ${post.body}`);
            console.log(`Name: ${post.name} Email: ${post.email}`);
        });
    } else {
        // What do when the request fails
        console.log('The request failed!');
    }

    // Code that should run regardless of the request status
    console.log('This always runs...');
};

// Create and send a GET request
// The first argument is the post type (GET, POST, PUT, DELETE, etc.)
// The second argument is the endpoint URL
xhr.open('GET', 'https://jsonplaceholder.typicode.com/users');
xhr.send();