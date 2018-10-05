
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
            "url": "/Fornecedor/ListaFornecedores",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [

            { "data": "Id", "autoWidth": true },
            { "data": "NomeFantasia", "autoWidth": true },
            { "data": "TelefoneUm", "autoWidth": true },
            { "data": "Email", "autoWidth": true },
        ]
    });

    // Exclui Fornecedor do banco de dados e da DataTable
    $('#excluir').click(function () {
        var fornecedorId = tabela.rows({ selected: true }).data()[0].Id;
        $.ajax({
            type: "GET",
            url: "/Fornecedor/DeletaFornecedor/" + fornecedorId,
            dataType: "json",
            success: function (response) {
                if (response.deletou) {
                    alert("Fornecedor apagado!");
                    tabela.ajax.reload();
                }
            }
        });
    });

    // envia id para controler
    $('#editar').click(function () {
        var FornecedorId = tabela.rows({ selected: true }).data()[0].Id;
        window.location.href = "/Fornecedor/UpdateForm/" + FornecedorId
    });
});