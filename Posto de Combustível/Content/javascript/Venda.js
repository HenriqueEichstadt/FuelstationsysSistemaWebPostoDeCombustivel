
$(document).ready(function () {
    //Select2 para Forma de pagamento
    $("#formaDePagamento").select2();

    //Select2 para Listar Produtos
    $.ajax({
        type: "GET",
        url: "/Estoque/ListaProdutos",
        data: { ListaProdutos: $("#selectProdutos").val() },
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (obj) {
            if (obj != null) {
                var data = obj.data;
                var selectboxProduto = $('#selectProdutos').select2();
                selectboxProduto.find('option').remove();
                $('<option>').val("").text("Selecione um Produto").appendTo(selectboxProduto);
                $.each(data, function (i, d) {
                    $('<option>').val(d.Id).text(d.Nome).appendTo(selectboxProduto);
                });
            }
        }
    });

    //Select2 para Clientes
    $.ajax({
        type: "GET",
        url: "/Cliente/ListaClientes",
        data: { ListaClientes: $("#selectClientes").val() },
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (obj) {
            if (obj != null) {
                var data = obj.data;
                var selectbox = $('#selectClientes').select2();
                selectbox.find('option').remove();
                $('<option>').val("").text("Selecione um Cliente").appendTo(selectbox);
                $.each(data, function (i, d) {
                    $('<option>').val(d.Id).text(d.Pessoa.Nome).appendTo(selectbox);
                });
            }
        }
    });

    // Adiciona o Produto na Tabela
    $("#adicionaProdutoNaTabela").click(function (event) {
        event.preventDefault();
        produto.Nome = $("#select2-selectProdutos-container").text();
        produto.Id = $("#selectProdutos").val();
        produto.Quantidade = $("#quantidade").val();
        produto.PrecoVenda = $("#valor").val();
        produto.precoSelecionado = produto.PrecoVenda;
        produto.precoSubtotal = produto.Quantidade * produto.PrecoVenda;





        // Botão para remover o produto na linha
        var botaoRemoverProduto = $("<button>").addClass("btn btn-sm btn-danger rounded-circle").append(
            $("<i>").addClass("fa fa-minus-circle")
        );
        botaoRemoverProduto.click(function (event) {
            event.preventDefault();
            idSelecionado = $(this).parent().parent().find(".IdDoProduto").text();
            arrayDeVendaEstoque.splice(arrayDeVendaEstoque.findIndex(p => p.ProdutoId == idSelecionado), 1);
            $(this).parent().parent().remove();
        });

        // Cria uma linha na tabela com os dados do produto
        $("#MyTable").append(
            $("<tr>").append(
                $("<td>").text(produto.Id).addClass("IdDoProduto")
            ).append(
                $("<td>").text(produto.Nome)
            ).append(
                $("<td>").text("R$" + Number.parseFloat(produto.precoSelecionado).toFixed(2).replace(".", ","))
            ).append(
                $("<td>").text(produto.Quantidade)
            ).append(
                $("<td>").text("R$" + Number.parseFloat(produto.precoSubtotal).toFixed(2).replace(".", ","))
            ).append(
                $("<td>").html(botaoRemoverProduto))
        );


        // adiciona os produtos no array
        arrayDeVendaEstoque.push(
            {
                EstoqueId: produto.Id,
                Unidades: produto.Quantidade,
                PrecoTotalItem: produto.precoSubtotal
            });

        var somaValores = 0;
        $.each(arrayDeVendaEstoque, function (i, vendaEstoque) {
            somaValores += produto.Quantidade * produto.PrecoVenda;
        });
        $("#totalAPagar").val("R$ " + Number.parseFloat(somaValores).toFixed(2).replace(".", ","));
    });

    $("#botaoFinalizar").click(function (event) {
        event.preventDefault();
        var venda = {
            ClienteId: $("#selectClientes").val(),
            Unidades: $("#totalUnidades").val(),
            FormaDePagamento: $("#formaDePagamento").val(),
            PrecoTotal: $("#totalAPagar").val(),
        };
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '/Venda/EmitirVenda',
            data: JSON.stringify({ venda: venda, arrayDeVendaEstoque: arrayDeVendaEstoque }),
            success: function (response) {
                alert("Venda efetuada");
            }
        });
    });


});


// Array para pegar produtos da tabela de venda
var arrayDeVendaEstoque = [];
var produto = {
    Id: "",
    Nome: "",
    PrecoVenda: "",
    Quantidade: "",
    precoSubtotal: "",
    precoSelecionado: ""
};



















