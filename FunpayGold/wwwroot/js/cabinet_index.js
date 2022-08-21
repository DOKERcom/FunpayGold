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
                    
                }

            }, false)
        })
})();
//---------------------------------------------

function TurnOffBot(botId) {

    const request = new XMLHttpRequest();
    const url = "/Cabinet/TurnOffBot";
    const params = "botId=" + botId;
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {

            var json = JSON.parse(request.responseText)

            ResultActionToast(json);

            if (json.resultCode == 200) {
                ChangeOnOffBtn(botId);
            }
        }

    });

    request.send(params);
}

function TurnOnBot(botId) {

    const request = new XMLHttpRequest();
    const url = "/Cabinet/TurnOnBot";
    const params = "botId=" + botId;
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {

            var json = JSON.parse(request.responseText)

            ResultActionToast(json);

            if (json.resultCode == 200)
            {
                ChangeOnOffBtn(botId);
            }
        }

    });

    request.send(params);
}

function ChangeOnOffBtn(botId) {
    var TurnOffBot = document.getElementById('TurnOffBot_' + botId);

    var TurnOnBot = document.getElementById('TurnOnBot_' + botId);

    if (TurnOffBot != null)
    {
        TurnOffBot.setAttribute("onclick", "TurnOnBot('" + botId + "')");

        TurnOffBot.id = "TurnOnBot_" + botId;

        TurnOffBot.classList.remove('stopbot');
        TurnOffBot.classList.add('startbot');

        TurnOffBot.firstChild.classList.remove('fa-stop');
        TurnOffBot.firstChild.classList.add('fa-play');
    }
    else if (TurnOnBot != null)
    {
        TurnOnBot.setAttribute("onclick", "TurnOffBot('" + botId + "')");

        TurnOnBot.id = "TurnOffBot_" + botId;

        TurnOnBot.classList.remove('startbot');
        TurnOnBot.classList.add('stopbot');

        TurnOnBot.firstChild.classList.remove('fa-play');
        TurnOnBot.firstChild.classList.add('fa-stop');
    }
}

function ResultActionToast(json) {
    if (json.resultCode == 200) {
        new Notify({
            title: 'Success',
            text: json.resultMessage,
            autoclose: true,
            status: 'success',
            autotimeout: 3000
        })
    }
    else if (json.resultCode == 400) {
        new Notify({
            title: 'Warning',
            text: json.resultMessage,
            autoclose: true,
            status: 'warning',
            autotimeout: 3000
        })
    }
    else if (json.resultCode == 500) {
        new Notify({
            title: 'Error',
            text: json.resultMessage,
            autoclose: true,
            status: 'error',
            autotimeout: 3000
        })
    }
}