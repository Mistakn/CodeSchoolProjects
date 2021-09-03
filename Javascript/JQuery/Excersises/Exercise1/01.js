$(() => {
    $('div.poem-stanza').addClass('highlight');
    $('.author').addClass('highlight');
    $('#paragraph1').css('color', 'red').css('background-color', 'blue').slideUp(5000).slideDown(5000);
});