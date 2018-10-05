
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


});
