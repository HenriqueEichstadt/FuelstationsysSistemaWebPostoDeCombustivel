
$(document).ready(function () {

    // Soma Valor Total das Vendas
    $.ajax({
		type: "GET",
        url: "/Home/ListaPrecoTotalVendas",
		dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    $("#valorTotalVendas").text("R$ " + field);
                }
            });
         

		},
    });

    // Soma total de vendas
    $.ajax({
        type: "GET",
        url: "/Home/SomaNumeroTotaDeVendas",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    $("#numeroTotalDeVendas").text(field);
                }
            });
        }
    });

    // Soma total de clientes
    $.ajax({
        type: "GET",
        url: "/Home/SomaNumeroDeClientes",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    $("#somaTotalClientes").text(field);
                }
            });
        }
    });

    // Soma total de clientes
    $.ajax({
        type: "GET",
        url: "/Home/ProdutosCadastradosNoEstoque",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    $("#quantidadeDeProdutosCadastrados").text(field);
                }
            });
        }
    });

    $.ajax({
        type: "GET",
        url: "/Home/ExibeNívelDaBombaUM",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    var qtd = Number.parseFloat(field).toFixed(3);
                    Number.parseFloat($("#litrosGasolinaComum").text("Litros  " + qtd));
                    var porcentagem = 0;
                    var litrosTotal = qtd;
                    porcentagem = Number.parseFloat(litrosTotal / 100).toFixed(2);
                    $("#porcentagemAcimaBombaUm").text(porcentagem + "%");
                    var valorPorcent = porcentagem + "%";
                    $("#barraDeProgressoGasCom").css("width", valorPorcent);

                    
                }
            });
        }
    });

    $.ajax({
        type: "GET",
        url: "/Home/ExibeNívelDaBombaDois",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    var qtd = Number.parseFloat(field).toFixed(3);
                    Number.parseFloat($("#litrosGasolinaAditivada").text("Litros  " + qtd));
                    var porcentagem = 0;
                    var litrosTotal = qtd;
                    porcentagem = Number.parseFloat(litrosTotal / 100).toFixed(2);
                    $("#porcentagemAcimaDaBombaDois").text(porcentagem + "%");
                    var valorPorcent = porcentagem + "%";
                    $("#barraDeProgressoGasAdit").css("width", valorPorcent);
                }
            });
        }
    });

    $.ajax({
        type: "GET",
        url: "/Home/ExibeNívelDaBombaTres",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    var qtd = Number.parseFloat(field).toFixed(3);
                    Number.parseFloat($("#litrosEtanol").text("Litros  " + qtd));
                    var porcentagem = 0;
                    var litrosTotal = qtd;
                    porcentagem = Number.parseFloat(litrosTotal / 100).toFixed(2);
                    $("#porcentagemAcimaBombaTres").text(porcentagem + "%");
                    var valorPorcent = porcentagem + "%";
                    $("#barraProgressoEtanol").css("width", valorPorcent);
                }
            });
        }
    });

    $.ajax({
        type: "GET",
        url: "/Home/ExibeNívelDaBombaQuatro",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    var qtd = Number.parseFloat(field).toFixed(3);
                    Number.parseFloat($("#litrosDiesel").text("Litros  " + qtd));
                    var porcentagem = 0;
                    var litrosTotal = qtd;
                    porcentagem = Number.parseFloat(litrosTotal / 100).toFixed(2);
                    $("#porcentagemAcimaDaBombaQuatro").text(porcentagem + "%");
                    var valorPorcent = porcentagem + "%";
                    $("#barraProgressoDiesel").css("width", valorPorcent);
                }
            });
        }
    });


});
