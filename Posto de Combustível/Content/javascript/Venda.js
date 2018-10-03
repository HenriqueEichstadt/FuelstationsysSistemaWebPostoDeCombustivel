
$(document).ready(function () {
    $("#ocultarValorVendido").hide();

    //Select2 para Forma de pagamento
    $("#formaDePagamento").select2();

    //Select2 para Listar Produtos
    $.ajax({
        type: "GET",
        url: "/Estoque/ListaProdutosParaAVenda",
        data: { ListaProdutos: $("#selectProdutos").val() },
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (obj) {
            if (obj != null) {
                var data = obj.data;
                var selectboxProduto = $('#selectProdutos').select2({
                    placeholder: "Selecione um Produto"
                });
                selectboxProduto.find('option').remove();
                $('<option>').val("").appendTo(selectboxProduto);
                $.each(data, function (i, d) {
                    $('<option>').val(d.Id).text(d.Nome).appendTo(selectboxProduto);
                    produtos.push({
                        PrecoVenda: d.PrecoVenda,
                        Id: d.Id,
                        Categoria: d.Categoria,
                        EstoqueAtual: d.EstoqueAtual
                    });
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

    // Ocultar campo de quantidade quando seleciona o tipo de Produto
    $("#selectProdutos").change(function () {
        var produtoIdSelecionado = $("#selectProdutos").val();
        dadosProduto = produtos[produtos.findIndex(p => p.Id == produtoIdSelecionado)];
        if (dadosProduto.Categoria == "C") {

            // $("#quantidade").val("");
            $("#ocultarCampo").hide();
            $("#ocultarValorVendido").show();
            $("#valor").val(dadosProduto.PrecoVenda);
        }
        else {
            $("#ocultarValorVendido").hide();
            $("#ocultarCampo").show();
            $("#valor").val(dadosProduto.PrecoVenda);
        }
        // Permite adicionar apenas o valor maximo no estoque no input
        var estoqueAtual = dadosProduto.EstoqueAtual;
        $("#quantidade").prop("max", estoqueAtual);
    });

    // Adiciona o Produto na Tabela
    $("#adicionaProdutoNaTabela").click(function (event) {
        event.preventDefault();
        if ($("#selectProdutos").val() == "") {
            alert("Selecione um produto para a venda!");
            return;
        }

        produto.Nome = $("#select2-selectProdutos-container").text();
        produto.Id = $("#selectProdutos").val();
        produto.PrecoVenda = $("#valor").val();
        produto.precoSelecionado = produto.PrecoVenda;
        produtoSelecionado = produto.PrecoVenda;
        // produto.Quantidade = $("#quantidade").val();
        //produto.valorSelecionadoDeCombustivel = $("#valorVendido").val();

        var estoqueAtual = dadosProduto.EstoqueAtual;
        var pegaValorCampo = $("#quantidade").val();
        if (pegaValorCampo > estoqueAtual) {
            alert("Há apenas " + estoqueAtual + " no estoque!");
            return;
        }

        if (dadosProduto.Categoria == "C") {
            
            if ($("#valorVendido").val() == "") {
                alert("Selecione um valor para a venda do Combustível!");
                return;
            }
            produto.valorSelecionadoDeCombustivel = Number.parseFloat($("#valorVendido").val());
            produto.PrecoVenda = Number.parseFloat($("#valor").val());
            var calculoQtd = produto.valorSelecionadoDeCombustivel / produto.PrecoVenda;
            produto.Quantidade = Number.parseFloat(calculoQtd).toFixed(3);
            produto.precoSubtotal = Number.parseFloat(produto.valorSelecionadoDeCombustivel);
        }
        else {
            produto.Quantidade = Number.parseFloat($("#quantidade").val());
            produto.precoSubtotal = produto.Quantidade * produto.PrecoVenda;
        }

        // Botão para remover o produto na linha
        var botaoRemoverProduto = $("<button>").addClass("btn btn-sm btn-danger rounded-circle").append(
            $("<i>").addClass("fa fa-minus-circle")
        );
        botaoRemoverProduto.click(function (event) {
            event.preventDefault();
            var idSelecionado = $(this).parent().parent().find(".IdDoProduto").text();
            arrayDeVendaEstoque.splice(arrayDeVendaEstoque.findIndex(p => p.EstoqueId == idSelecionado), 1);
            $(this).parent().parent().remove();
            // atualiza valores dos campos Quantidade e PreçoTotal
            AtualizaValoresDaQuantidadeEDoPreco();
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
                $("<td>").text(Number.parseFloat(produto.Quantidade).toFixed(2).replace(".", ",") + " L")
            ).append(
                $("<td>").text("R$" + Number.parseFloat(produto.precoSubtotal).toFixed(2).replace(".", ","))
            ).append(
                $("<td>").html(botaoRemoverProduto))
        );

        // adiciona os produtos no array
        arrayDeVendaEstoque.push(
            {
                EstoqueId: produto.Id,
                Unidades: Number.parseFloat(produto.Quantidade),
                PrecoTotalItem: produto.precoSubtotal
            });
        // Atualiza valores dos campos Quantidade e PreçoTotal
        AtualizaValoresDaQuantidadeEDoPreco();
    });

    // Ações no botão finalizar
    $("#botaoFinalizar").click(function (event) {
        event.preventDefault();
        var valorFinalDaVenda = $("#valorFinalDaVenda").val();
        if ($("#formaDePagamento").val() == "") {
            alert("Selecione uma forma de pagamento!");
            return;
        }
        else {
            var venda = {
                ClienteId: $("#selectClientes").val(),
                Unidades: Number.parseFloat($("#totalUnidades").val()),
                FormaDePagamento: $("#formaDePagamento").val(),
                PrecoTotal: Number.parseFloat(valorFinalDaVenda)
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
        }
    });


});

// Variavel global para pegar os valores do produto escolhido no select2
var dadosProduto = "";

// Array para pegar produtos da tabela de venda
var arrayDeVendaEstoque = [];
var produto = {
    Id: 0,
    Nome: "",
    PrecoVenda: 0,
    Quantidade: 0,
    precoSubtotal: 0,
    precoSelecionado: 0,
    valorSelecionadoDeCombustivel: 0
};

var produtos = [];

// function para atualizar valores dos campos Quantidade e PreçoTotal
function AtualizaValoresDaQuantidadeEDoPreco() {

    // limpa valores dos campos ValorTotal e Quantidade
    AtualizaCamposValorEQuantidade();

    var somaValores = 0;
    var somaUnidades = 0;
    $.each(arrayDeVendaEstoque, function (i, vendaEstoque) {
        somaValores += Number.parseFloat(vendaEstoque.PrecoTotalItem);
        somaUnidades += Number.parseFloat(vendaEstoque.Unidades);
    });
    $("#totalAPagar").val("R$ " + Number.parseFloat(somaValores).toFixed(2).replace(".", ","));
    $("#totalUnidades").val(somaUnidades);
    $("#valorFinalDaVenda").val(Number.parseFloat(somaValores));
}

// function para limpar os campos de unidades e valortotal
function AtualizaCamposValorEQuantidade() {
    $("#totalAPagar").val("");
    $("#totalUnidades").val("");
}














