$(document).ready(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/statistic").build();
    $("#connstatus").text(connection.state);
    connection.start().then(() => {
        $("#connstatus").text(connection.state);
        setInterval(() => {
            connection.invoke("SendStacistic");
        }, 1000);
    }).catch((err) => { console.log(err) });
    connection.on("ProductCount", (productcountvalue) => {
        $("#productcount").text(productcountvalue);
    });
    connection.on("ProductMaxPrice", (productmaxvalue) => {
        $("#productmaxprice").text(productmaxvalue);
    });
    connection.on("ProductMinPrice", (productminvalue) => {
        $("#productminprice").text(productminvalue);
    });
    connection.on("ProductPriceAvg", (productpriceavg) => {
        $("#productavg").text(productpriceavg);
    });

});