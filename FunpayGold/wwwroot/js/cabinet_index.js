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
                    UpdateBotSettings();
                }

            }, false)
        })
})();
//---------------------------------------------

function ModalInputSetter(elemId, value) {
    var elem = document.getElementById(elemId);
    if (value != undefined)
        elem.setAttribute("value", value);
}


function UpdateBotActivityModal(botid) {

    var bots = CabinetViewModel.user.bots;

    var tbody = document.getElementById('BotActivityModal').getElementsByTagName('tbody')[0];

    var Parent = tbody;
    while (Parent.hasChildNodes()) {
        Parent.removeChild(Parent.lastChild);
    }

    bots.forEach(function (bot) {
        if (bot.id == botid) {

            var activities = bot.botActivities;

            activities.forEach(function (activity) {
                tbody.insertRow().innerHTML = '<tr><td>' + activity.message + '</td></tr>';
            });
        }
    });

}

function SetBotSettingsModal(botId) {

    var bots = CabinetViewModel.user.bots;

    document.getElementById('SettingsValidationForm').classList.remove('was-validated');

    bots.forEach(function (bot) {
        if (bot.id == botId) {

            ModalInputSetter('BotId', bot.id);
            ModalInputSetter('BotName', bot.name);
            ModalInputSetter('ProxyIp', bot.proxyIp);
            ModalInputSetter('ProxyLogin', bot.proxyLogin);
            ModalInputSetter('ProxyPassword', bot.proxyPassword);
            ModalInputSetter('AccountLogin', bot.accountLogin);
            ModalInputSetter('AccountPassword', bot.accountPassword);
            ModalInputSetter('AccountMobile', bot.accountMobile);
            ModalInputSetter('TelegramBotKey', bot.telegramBotKey);
        }
    });

}

function UpdateBotSettings() {

    var id = document.getElementById('BotId').value;
    var name = document.getElementById('BotName').value;

    var ProxyIp = document.getElementById('ProxyIp').value;
    var ProxyLogin = document.getElementById('ProxyLogin').value;
    var ProxyPassword = document.getElementById('ProxyPassword').value;

    var AccountLogin = document.getElementById('AccountLogin').value;
    var AccountPassword = document.getElementById('AccountPassword').value;
    var AccountMobile = document.getElementById('AccountMobile').value;

    var TelegramBotKey = document.getElementById('TelegramBotKey').value;

    const request = new XMLHttpRequest();
    const url = "/Cabinet/UpdateBotSettings";
    const params = "Id=" + id
        + "&Name=" + name
        + "&ProxyIp=" + ProxyIp
        + "&ProxyLogin=" + ProxyLogin
        + "&ProxyPassword=" + ProxyPassword
        + "&AccountLogin=" + AccountLogin
        + "&AccountPassword=" + AccountPassword
        + "&AccountMobile=" + AccountMobile
        + "&TelegramBotKey=" + TelegramBotKey;


    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {

            var json = JSON.parse(request.responseText)

            ResultActionToast(json);
        }

    });

    request.send(params);
}

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