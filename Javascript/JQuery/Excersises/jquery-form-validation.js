$(() => {

    $('#btnForm').click(function (e) {
        e.preventDefault();

        let formValid = true;
        let userNameValue = $('#name').val();
        let emailValue = $('#mail').val();
        let messageValue = $('#msg').val();

        if (userNameValue == '') {
            document.getElementById('nameErrorMessage').innerHTML = '<span>Name is required</span>';
            formValid = false;
        } else {
            document.getElementById('nameErrorMessage').innerHTML = '';
        }

        if (emailValue == '') {
            document.getElementById('emailErrorMessage').innerHTML = '<span>Email is required</span>';
            formValid = false;
        } else {
            document.getElementById('emailErrorMessage').innerHTML = '';
        }

        if (messageValue == '') {
            document.getElementById('messageErrorMessage').innerHTML = '<span>Message is required</span>';
            formValid = false;
        } else {
            document.getElementById('messageErrorMessage').innerHTML = '';
        }


        if (formValid) {
            alert('Message sent');
        }
    });
});