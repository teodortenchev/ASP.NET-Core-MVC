const appUrl = 'https://localhost:44358/api/';
let currentUsername = null;

setInterval(loadMessages, 1000);


$('#reset-data').hide();
loadMessages();

function chooseUsername() {
    let username = $('#username').val();

    if (username.length === 0) {
        alert('Username can\'t be empty');
        return;
    }


    currentUsername = username;
    $('#username-choice').text(currentUsername);
    $('#choose-data').hide();
    $('#reset-data').show();
}

function resetUsername() {
    currentUsername = null;

    $('#choose-data').show();
    $('#reset-data').hide();
}

function renderMessages(data) {
    $('#messages').empty();

    for (let message of data) {
        $('#messages')
            .append('<div class="message d-flex justify-content-start"><strong>' +
                message.user + '</strong >: ' + message.content
                + '</div >')
    }
}

function loadMessages() {
    $.get({
        url: appUrl + 'messages/all',
        success: function success(data) {
            renderMessages(data);
        },
        error: function error(error) {
            console.log(error)
        }
    });
}

function createMessage() {

    let content = $('#message').val();
    let username = currentUsername;


    if (username == null) {
        alert('Username must be selected.');
        return;
    }

    if (content.length === 0) {
        alert('Please add message');
        return;
    }



    $.post({
        url: appUrl + 'messages/create',
        headers: {
            'Content-Type': 'application/json'
        },

        data: JSON.stringify({ content: content, user: username }),

        success: function success(data) {
            loadMessages();
        },
        error: function error(error) {
            console.log(error);
        }
    });
}
