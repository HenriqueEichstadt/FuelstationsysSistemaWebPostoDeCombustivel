
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
            "url": "/Funcionario/ListaFuncionarios",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "Id", "autoWidth": true, },
            { "data": "NomeUsuario", "autoWidth": true },
            { "data": "Cargo", "autoWidth": true },
            { "data": "Pessoa.Nome", "autoWidth": true },
            {
                "data": "NivelAcesso",
                "autoWidth": true,
                render: function (data, type, row) {
                    if (row.NivelAcesso == 0) {
                        return "Administrador";
                    }
                    else {
                        return "Funcionario";
                    }
                }
            }
        ]
    });

    // Exclui Funcionario do banco de dados e da DataTable
    $('#excluir').click(function () {
        var funcionarioId = tabela.rows({ selected: true }).data()[0].Id;
        $.ajax({
            type: "GET",
            url: "/Funcionario/DeletaFuncionario/" + funcionarioId,
            dataType: "json",
            success: function (response) {
                if (response.deletou) {
                    alert("Funcionário apagado!");
                    tabela.ajax.reload();
                }
            }
        });
    });



    function AlteraCadastro() {
        $.ajax({
            type: "POST",
            url: "/Funcionario/ModificaFuncionarios",
            data: { Atualiza: $("#listaFuncionarios").val() },
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
        });
    }

    // envia id para controler
    $('#editar').click(function () {
        var FuncionarioId = tabela.rows({ selected: true }).data()[0].Id;
        window.location.href = "/Funcionario/UpdateForm/" + FuncionarioId
    });
});