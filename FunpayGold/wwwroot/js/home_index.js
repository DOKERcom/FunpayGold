//-------------------Forms validation---------------------------
(function () {
    'use strict'

    var forms = document.querySelectorAll('.needs-validation')

    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {

                event.preventDefault();
                event.stopPropagation();

                form.classList.add('was-validated');

                if (form.checkValidity()) {
                    if (form.getAttribute("id") == "RegisterUserForm") {

                        Register();

                    }
                    else if (form.getAttribute("id") == "SigninUserForm") {

                        SignIn();
                    }
                }

            }, false)
        })
})();
//---------------------------------------------

document.getElementById('GoToRegister').onclick = function () {
    document.getElementById('SigninUserForm').classList.add('hideform');
    document.getElementById('RegisterUserForm').classList.remove('hideform');
}

document.getElementById('GoToSignIn').onclick = function () {
    document.getElementById('RegisterUserForm').classList.add('hideform');
    document.getElementById('SigninUserForm').classList.remove('hideform');
}

function SignIn() {

    username = document.getElementById('S_Username').value;
    password = document.getElementById('S_Password').value;
    const request = new XMLHttpRequest();
    const url = "/Home/SignIn";
    const params = "UserName=" + username + "&Password=" + password;
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {
            ResultActionToast(JSON.parse(request.responseText));
        }

    });

    request.send(params);
}

function Register() {

    username = document.getElementById('R_Username').value;
    password = document.getElementById('R_Password').value;
    email = document.getElementById('R_Email').value;
    const request = new XMLHttpRequest();
    const url = "/Home/Register";
    const params = "UserName=" + username + "&Password=" + password + "&Email=" + email;
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {
            ResultActionToast(JSON.parse(request.responseText));
        }

    });

    request.send(params);
}

function ResultActionToast(json) {
    if (json.resultAction == "200") {
        window.location.href = "/Cabinet";
    }
    else if (json.resultAction == "400") {
        new Toast({
            title: 'Warning',
            text: json.resultMessage,
            theme: 'warning',
            autohide: true,
            interval: 3000
        });
    }
    else if (json.resultAction == "500") {
        new Toast({
            title: 'Error',
            text: json.resultMessage,
            theme: 'danger',
            autohide: true,
            interval: 3000
        });
    }
}