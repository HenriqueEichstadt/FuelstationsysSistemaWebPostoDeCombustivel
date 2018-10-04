
$(document).ready(function () {
	$.ajax({
		type: "GET",
        url: "/Home/ListaPrecoTotalVendas",
		dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $.each(result, function (i, field) {
                {
                    $("#valorTotalVendas").text(field);
                }
            });
         

		},
    });

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


});
