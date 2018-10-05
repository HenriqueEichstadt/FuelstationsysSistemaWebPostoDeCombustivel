
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
        url: "/Cliente/ListaClientesVenda",
        data: { ListaClientes: $("#selectClientes").val() },
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (obj) {
            if (obj != null) {
                var selectbox = $('#selectClientes').select2({
                    placeholder: "Selecione um Cliente"
                });
                selectbox.find('option').remove();
                $('<option>').val("").appendTo(selectbox);
                $.each(obj, function (i, d) {
                    $('<option>').val(d.Id).text(d.Nome + "   -   " + d.Placa).appendTo(selectbox);
                    clientes.push({
                        Id: d.Id,
                        Pontos: d.Pontos
                    });
                });
            }
        },
        
    });

    // Ocultar campo de quantidade quando seleciona o tipo de Produto
    $("#selectProdutos").change(function () {
        var produtoIdSelecionado = $("#selectProdutos").val();
        dadosProduto = produtos[produtos.findIndex(p => p.Id == produtoIdSelecionado)];
        if (dadosProduto.Categoria == "C") {

            $("#ocultarCampo").hide();
            $("#ocultarValorVendido").show();
            $("#valor").val(dadosProduto.PrecoVenda);
        }
        else {
            $("#ocultarValorVendido").hide();
            $("#ocultarCampo").show();
            $("#valor").val(dadosProduto.PrecoVenda);
        }
        // Permite adicionar apenas o valor maximo do produto no estoque
        var estoqueAtual = dadosProduto.EstoqueAtual;
        $("#quantidade").prop("max", estoqueAtual);

        // permite adicionar apenas o valor total em reais do combustivel do estoque
        var preco = dadosProduto.PrecoVenda;
        valorTotalQuePodeAdicionar = estoqueAtual * preco;
        $("#valorVendido").prop("max", valorTotalQuePodeAdicionar);

    });

    // Pega os dados do cliente selecionado
    $("#selectClientes").change(function () {
        var clienteSelecionado = $("#selectClientes").val();
        dadosCliente = clientes[clientes.findIndex(c => c.Id == clienteSelecionado)];
        // Exibe os pontos do cliente
        var pontosDoCliente = dadosCliente.Pontos;
        $("#totalPontosDoCliente").val(pontosDoCliente + "  Pontos");
    });

    // Muda input para pontos se for por troca de pontos
    $("#formaDePagamento").change(function () {
        var formaSelecionada = $("#formaDePagamento").val();
        if (formaSelecionada == '3') {
            $("#totaldaVendaEmPontosOuReais").text("Troca por Pontos");
            //$("#totalAPagar").val(Number.parseFloat(somaValores * 100).toFixed(2).replace(".", ","));    
        }
        else {
            $("#totaldaVendaEmPontosOuReais").text("Total a pagar");
            //$("#totalAPagar").val("R$ " + Number.parseFloat(somaValores).toFixed(2).replace(".", ","));

        }
    });

    // Adiciona o Produto na Tabela
    $("#adicionaProdutoNaTabela").click(function (event) {
        event.preventDefault();
        if ($("#selectProdutos").val() == "") {
            $.notify("Selecione um produto para a venda!");
            return;
        }

        produto.Nome = $("#select2-selectProdutos-container").text();
        produto.Id = $("#selectProdutos").val();
        produto.PrecoVenda = $("#valor").val();
        produto.precoSelecionado = produto.PrecoVenda;
        produtoSelecionado = produto.PrecoVenda;

        if (dadosProduto.Categoria == "P") {

            var estoqueAtual = dadosProduto.EstoqueAtual;
            var pegaValorCampo = $("#quantidade").val();
            if (pegaValorCampo > estoqueAtual) {
                $.notify("Há apenas " + estoqueAtual + " unidades no Estoque!");
                return;
            }
        }
        else {
            var valorAdicionado = $("#valorVendido").val();
            if (valorAdicionado > valorTotalQuePodeAdicionar) {
                $.notify("Valor máximo de R$: " + Number.parseFloat(valorTotalQuePodeAdicionar - 1).toFixed(2) + " disponível para venda!");
                return;
            }
        }

        var IdAtual = dadosProduto.Id;
        var buscaId = 0;
        $.each(arrayDeVendaEstoque, function (i, vendaEstoque) {
            buscaId = Number.parseFloat(vendaEstoque.EstoqueId);
        });
        if (buscaId == IdAtual) {
            $.notify("Este produto já está adicionado na venda !");
            return;
        }

        if (dadosProduto.Categoria == "C") {

            if ($("#valorVendido").val() == "") {
                $.notify("Selecione um valor para a venda do Combustível!");

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
                $("<td>").text(Number.parseFloat(produto.Quantidade).toFixed(2).replace(".", ","))
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
        var vendaEstoque = arrayDeVendaEstoque;
        if (vendaEstoque == "") {
            $.notify("Venda vazia!");
            return;
        }
        var valorFinalDaVenda = $("#valorFinalDaVenda").val();
        if ($("#formaDePagamento").val() == "") {
            $.notify("Selecione uma forma de pagamento!");
            return;
        }
        else {
            var venda = {
                ClienteId: $("#selectClientes").val(),
                Unidades: Number.parseFloat($("#totalUnidades").val()),
                FormaDePagamento: $("#formaDePagamento").val(),
                PrecoTotal: Number.parseFloat(valorFinalDaVenda)
            };

            var formadePagamento = $("#formaDePagamento").val();
            if (formadePagamento == 3) {
                var pontosDoCliente = dadosCliente.Pontos;
                var valorTotalVenda = venda.PrecoTotal * 100;
                if (valorTotalVenda > pontosDoCliente) {
                    $.notify("O cliente não possui pontos o suficiente para a troca ");
                    return;
                }
            }

            $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: '/Venda/EmitirVenda',
                data: JSON.stringify({ venda: venda, arrayDeVendaEstoque: arrayDeVendaEstoque }),
                success: function (response) {
                    var formadePagamento = $("#formaDePagamento").val();
                    var cliente = $("#selectClientes").val();

                    if (cliente != "" && formadePagamento == 3) {
                        LimpaVenda();
                        return $.notify("Troca por Pontos efetuada com sucesso!");
                    }
                    if (cliente == "" && formadePagamento == 3) {
                        return $.notify("Selecione um cliente para trocar por pontos!");
                    }
                    if (cliente != "" && formadePagamento == 0 || formadePagamento == 1) {
                        var valorPontuado = venda.PrecoTotal;
                        LimpaVenda();
                        return $.notify("Venda Efetuada com Sucesso! " + "O Cliente Pontuou " + valorPontuado + " pontos para o Programa de Fidelidade!");
                    }
                    else {
                        LimpaVenda();
                        return $.notify("Venda Efetuada com Sucesso");
                    }
                }
            });
        }
    });


});

// Variavel global para pegar os valores do produto escolhido no select2
var dadosProduto = "";
var dadosCliente = "";
var valorTotalQuePodeAdicionar;
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
var clientes = [];
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

    var pagar = $("#formaDePagamento").val();
    if (pagar == '3') {
        $("#totalAPagar").val(Number.parseFloat(somaValores * 100).toFixed(2).replace(".", ","));
    }
    else {
        $("#totalAPagar").val("R$ " + Number.parseFloat(somaValores).toFixed(2).replace(".", ","));
    }
    $("#totalUnidades").val(somaUnidades);
    $("#valorFinalDaVenda").val(Number.parseFloat(somaValores));
}

// function para limpar os campos de unidades e valortotal
function AtualizaCamposValorEQuantidade() {
    $("#totalAPagar").val("");
    $("#totalUnidades").val("");
}

function LimpaVenda() {
	
	$("#formaDePagamento").val("");
	$("#selectClientes").remove();
	$('#selectProdutos').val("");
	$("#valor").val("");
	$("#quantidade").val("");
	$("#valorVendido").val("");
	$("#totalAPagar").val("");
	$("#totalUnidades").val("");
	$("#valorFinalDaVenda").val("");
    $("#totalPontosDoCliente").val("");
    produtos = [];
	clientes = [];
	arrayDeVendaEstoque = [];
	produto = {};
	dadosProduto = "";
	dadosCliente = "";
    valorTotalQuePodeAdicionar = "";


}













