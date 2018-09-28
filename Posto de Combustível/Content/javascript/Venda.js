
$(document).ready(function () {

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
    //Select2 para Forma de pagamento
    $("#formaDePagamento").select2();

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

});


function removeProduto() {
    event.preventDefault();
    var linha = $(this).parent().parent();
    linha.fadeOut(1000);
    setTimeout(function () {
        linha.remove();
    }, 1000);
}



function gravarNaTabela() {
    var proximoId = 0
    $('#tabelaVenda tr:last').after('<tr><td>' + $('#selectProdutos').val() + '</td>' +
        '<td>' + $('#quantidade').val() + '</td>' + '<td>' + $('#valor').val() + '</td></tr>');
    proximoId = proximoId;
}

function Mostraprodutos() {
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
}

//var products = $('#tabelaVenda input[type="text"]').map(function () {
//    var obj = new Object();
//    obj.Id = $(this).data("id");
//    obj.Name = $(this).val();
//    obj.Status = 1;
//    return JSON.stringify(obj);
//}).get();
//$.ajax({
//    contentType: 'application/json; charset=utf-8',
//    dataType: 'json', < font ></font >
//    url: '@Url.Action("UpdateProducts")',
//    type: 'post',
//    data: JSON.stringify({ products: products, statusId: 1 }) 
//    })
//    .done(function (result) {
//        alert("foi");
//    });

//function deleteRow(r) {
//    var i = r.parentNode.parentNode.rowIndex;
//    document.getElementById("MyTable").deleteRow(i);
//}