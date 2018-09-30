
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








    // Pega os valores dos campos da tabela de vendas
    $("#tabelaVenda").change(function () {
        if ($(this).val() == "") return;
        var dadosDoProduto = $(this).val().match(/id=(.*)&pve=(.*)&qua=(.*)/);
        produto.Id = dadosDoProduto[1];
        produto.Nome = $("#select2-selectProdutos-container").text();
        produto.PrecoVenda = dadosDoProduto[2];
        produto.Quantidade = dadosDoProduto[3];
    });


    // Adiciona o Produto na Tabela
    $("#botaoFinalizar").click(function (event) {
        event.preventDefault();
        produto.Quantidade = $("#quantidade").val();
        produto.PrecoVenda = $("#valor").val();
        switch (produto.tipoPrecoSelecionado) {
            case "2":
                var precoSelecionado = produto.precoRecarga;
                produto.precoSubtotal = produto.quantidade * produto.precoRecarga;
                break;
            case "3":
                precoSelecionado = produto.precoTroca;
                produto.precoSubtotal = produto.quantidade * produto.precoTroca;
                break;
            default:
                precoSelecionado = produto.PrecoVenda;
                produto.precoSubtotal = produto.Quantidade * produto.PrecoVenda;
        }
        var botaoRemover = $("<button>").addClass("btn btn-sm btn-danger rounded-circle").append(
            $("<i>").addClass("fa fa-minus-circle")
        );

        // Botão para remover o produto na linha
        var botaoRemoverProduto = $("<button>").addClass("btn btn-sm btn-danger rounded-circle").append(
            $("<i>").addClass("fa fa-minus-circle")
        );
        botaoRemoverProduto.click(function (event) {
            event.preventDefault();
            idSelecionado = $(this).parent().parent().find(".ClassIdProduto").text();
            arrayDeVendaEstoque.splice(arrayDeVendaEstoque.findIndex(p => p.ProdutoId == idSelecionado), 1);
            $(this).parent().parent().remove();
        });

        // Cria uma linha na tabela com os dados do produto
        $("#MyTable").append(
            $("<tr>").append(
                $("<td>").text(produto.Id).addClass("ClassIdProduto")
            ).append(
                $("<td>").text(produto.Nome)
            ).append(
                $("<td>").text("R$" + Number.parseFloat(precoSelecionado).toFixed(2).replace(".", ",")) // falta arrumar
            ).append(
                $("<td>").text(produto.Quantidade)
            ).append(
                $("<td>").text("R$" + Number.parseFloat(produto.precoSubtotal).toFixed(2).replace(".", ","))
            ).append(
                $("<td>").html(botaoRemoverProduto)
            )
        );



        // adiciona os produtos no array
        arrayDeVendaEstoque.push(
            {
                ProdutoId: produto.Id,
                Quantidade: produto.Quantidade,
                PrecoVenda: produto.PrecoVenda
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
        precoSubtotal: ""
    };



















