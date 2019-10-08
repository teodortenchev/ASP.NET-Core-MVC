const appUrl = 'https://localhost:44358/api/';
let currentUsername = null;
let token = null;

setInterval(loadMessages, 1000);


$('#loginform').hide();
$('#registerform').hide();
$('#loggedin-view').hide();

loadMessages();

function showRegister() {
    $('#loginform').hide();
    $('#registerform').show();

}

function showLogin() {
    $('#registerform').hide();
    $('#loginform').show();

}
function showLoggedView() {
    $('#loginform').hide();
    $('#guest-view').hide();
    $('#registerform').hide();
    $('#loggedin-view').show();
    
    $('#username-choice').text(currentUsername);
}

function showGuestView() {
    $('#loginform').hide();
    $('#guest-view').hide();
    $('#registerform').hide();
    $('#loggedin-view').hide();
    $('#guest-view').show();

}

function Login() {
    let username = $('#loginusername').val();
    let password = $('#loginpassword').val();


    $.post({
        url: appUrl + 'users/authenticate',
        headers: {
            'Content-Type': 'application/json'
        },

        data: JSON.stringify({ username: username, password: password }),

        success: function success(data) {
            currentUsername = data.username;
            showLoggedView();

            token = data.token;
            console.log('user ' + currentUsername);
            console.log('token ' + token);
        },
        error: function error(error) {
            console.log(error);
        }
    });

}

function Register() {
    let username = $('#username').val();
    let password = $('#password').val();

    if (username.length === 0 || username.length < 4 || username.length > 50) {
        alert('Invalid username');
        return;
    }

    if (password.length === 0 || password.length < 6 || password.length > 50) {
        alert('Invalid password');
        return;
    }

    $.post({
        url: appUrl + 'users/create',
        headers: {
            'Content-Type': 'application/json'
        },

        data: JSON.stringify({ username: username, password: password }),

        success: function success(data) {
            showLogin();
        },
        error: function error(error) {
            console.log(error);
        }
    });

}


function Logout() {
    currentUsername = null;
    token = null;

    showGuestView();
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
        alert('Please log in to post messages.');
        return;
    }

    if (content.length === 0) {
        alert('Please add message');
        return;
    }



    $.post({
        url: appUrl + 'messages/create',
        headers: {
            'Authorization': 'Bearer ' + token,
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


