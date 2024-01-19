$(document).ready(() => {

    var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7028/SignalRHub").build();
    $("#connstatus").text(connection.state);
    connection.start().then(() => {
        $("#connstatus").text(connection.state);
        setInterval(() => {
            connection.invoke("SendNotification");
        }, 1000);
    }).catch((err) => { console.log(err) });


    connection.on("ReceiveNotificationCountByFalse", (value) => {
        $("#notificationcount").text(value);
    });

    connection.on("ReceiveNotificationListByFalse", (value) => {
        console.log(value);
        $("#notilist").empty();
        for (var i = 0; i < value.length; i++) {
            $("#notilist").append(`<a href="#">
                                                    <div class="${value[i].type}"><i class="${value[i].icon}"></i></div>
                                                    <div class="notif-content">
                                                    <span class="block">
                                                    ${value[i].description}
                                                    </span>
                                                    <span class="time">${value[i].date}</span>
                                                    </div>
                                                    </a>
                                                    `)
        };
    });
});