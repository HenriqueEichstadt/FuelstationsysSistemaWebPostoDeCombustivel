
$(document).ready(function () {
	$.ajax({
		type: "GET",
		url: "/Home/ListaVendas",
		dataType: 'json',
		contentType: "application/json; charset=utf-8",
		success: function (obj) {
			var data = obj.data;
			data.push({
				PrecoTotal: d.PrecoTotal,
				Id: d.Id,
				Unidades: d.Unidades,
			});
		}
	});

	// foreach para contar o valor das vendas
	var somaValores = 0;
	$.each(data, function (i, venda) {
		somaValores += Number.parseFloat(venda.PrecoTotal);
		//somaUnidades += Number.parseFloat(vendaEstoque.Unidades);
	});
	$("#valorTotalVendas").text(somaValores);

});

var detalhesDaVenda = [];