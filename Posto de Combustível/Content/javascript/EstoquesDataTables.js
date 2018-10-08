
$(document).ready(function () {
    moment.locale("pt-br");
    var tabela = $('#MyEstoque').DataTable({
        dom: 'Blftip',
        select: { style: 'single' },
        "language":
        {
            "info": "Total: _TOTAL_ marcas(s) - Página _PAGE_ de _PAGES_.",
            "zeroRecords": "Nenhum resultado encontrado.",
            "infoEmpty": "Mostrando 0 marcas.",
            "infoFiltered": "(Filtrado de _MAX_ itens.)",
            "decimal": ",",
            "thousands": ".",
            "search": "",
            "loadingRecords": "Carregando...",
            "processing": "Processando...",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            },
            "lengthMenu": "Marcas por página:  _MENU_",
            select: {
                rows: {
                    _: "%d marcas selecionadas.",
                    0: "Clique em uma marca para selecioná-la.",
                    1: "1 marca selecionada."
                }
            }
        },
        "ajax": {
            "url": "/Estoque/ListaProdutos",
            "type": "GET",
            "datatype": "json",
            "dom": 'Bfrtip',
            "buttons": [
                'Adicionar', 'Alterar', 'Excluir'
            ],
        },
        "columns": [
            { "data": "Id", "autoWidth": true, },
            { "data": "Nome", "autoWidth": true },
            {
                "data": "Marca",
                "autoWidth": true,
                render: function (data, type, row) {
                    if (row.Marca == null) {
                        return "Sem Marca";
                    }
                    else {
                        return data;
                    }
                }
            },
            {
                "data": "Categoria",
                "autoWidth": true,
                render: function (data, type, row) {
                    if (row.Categoria == 'C') {
                        return "Combustível";
                    }
                    else {
                        return "Produto";
                    }
                }
            },
            { "data": "PrecoVenda", "autoWidth": true },
            { "data": "PrecoCusto", "autoWidth": true },
            { "data": "EstoqueAtual", "autoWidth": true },
            {
                "data": "LimiteEstoque",
                "autoWidth": true,
                render: function (data, type, row) {
                    if (row.LimiteEstoque == null) {
                        return "Sem Limite";
                    }
                    else {
                        return data;
                    }
                }
            },
            {
                "data": "Validade", "autoWidth": true,
                render: function (data, row) {
                    return moment(row.Validade).format('L');

                }
            },
           S {
                "data": "TrocaPontosFidelidade", "autoWidth": true,
                render: function (data, type, row) {
                    if (row.TrocaPontosFidelidade == null) {
                        return "0";
                    }
                    else {
                        return data;
                    }
                }
            }
        ],
    });

    // Inativa produto no banco de dados e da DataTable
    $('#excluir').click(function () {
        var ProdutoId = tabela.rows({ selected: true }).data()[0].Id;
        $.ajax({
            type: "GET",
            url: "/Estoque/InativaProduto/" + ProdutoId,
            dataType: "json",
            success: function (response) {
                if (response.inativou) {
                    alert("Produto apagado.");
                    tabela.ajax.reload();
                }
            }
        });
    });

    // envia id para controler
    $('#editar').click(function () {
        var ProdutoId = tabela.rows({ selected: true }).data()[0].Id;
        window.location.href = "/Estoque/UpdateForm/" + ProdutoId
    });

});