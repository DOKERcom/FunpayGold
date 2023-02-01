//alert(AdminPanelModel.users[0].username);

function UpdateBotSettingsModal(userid) {

    var users = AdminPanelViewModel.users;

    var tbody = document.getElementById('BotSettingsModalTable').getElementsByTagName('tbody')[0];

    var Parent = tbody;
    while (Parent.hasChildNodes()) {
        Parent.removeChild(Parent.lastChild);
    }

    var btnAddBot = document.getElementById('AddBotButton');

    users.forEach(function (user) {
        if (user.id == userid) {

            var bots = user.bots;

            bots.forEach(function (bot) {
                tbody.insertRow().innerHTML = '<tr><td>' + bot.id + '</td><td><button onclick="DeleteBot(\'' + bot.id + '\');" class="deletebot btn btn-primary btn-sm"><i class="fa-solid fa-trash-can"></i></button></td></tr>';
            });

            btnAddBot.setAttribute("onclick", "AddBot('"+userid+"')");
        }
    });

}

function AddBot(userid) {

    const request = new XMLHttpRequest();
    const url = "/AdminPanel/AddBot";
    const params = "userId=" + userid;
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {
            ResultActionToast(JSON.parse(request.responseText));
        }

    });

    request.send(params);
}

function DeleteBot(botid) {

    const request = new XMLHttpRequest();
    const url = "/AdminPanel/DeleteBot";
    const params = "botId=" + botid;
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