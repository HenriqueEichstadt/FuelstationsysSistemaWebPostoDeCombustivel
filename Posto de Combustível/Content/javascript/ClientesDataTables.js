$(document).ready(function () {
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
            "url": "/Cliente/ListaClientes",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "Id", "autoWidth": true, },
            { "data": "Pessoa.Nome", "autoWidth": true },
            { "data": "Pontos", "autoWidth": true },

        ]
    });

    // Inativa CLiente no banco de dados e da DataTable
    $('#excluir').click(function () {
        var clienteId = tabela.rows({ selected: true }).data()[0].Id;
        $.ajax({
            type: "GET",
            url: "/Cliente/InativaCliente/" + clienteId,
            dataType: "json",
            success: function (response) {
                if (response.inativou) {
                    alert("Cliente apagado!");
                    tabela.ajax.reload();
                }
            }
        });
    });

    // envia id para controler
    $('#editar').click(function () {
        var ClienteId = tabela.rows({ selected: true }).data()[0].Id;
        window.location.href = "/Cliente/UpdateForm/" + ClienteId
    });

});