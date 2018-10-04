// Validações de Formulário
$(document).ready(function () {
    $("#FormCadastro").validate({
        rules: {
            "estoque.Nome": {
                required: true,
                maxlength: 50
            },
            "estoque.Categoria": {
                required: true
            },
            "estoque.PrecoCusto": {
                required: true
            },
            "estoque.PrecoVenda": {
                required: true
            },
            "estoque.Descricao": {
                maxlength: 200
            },
            "estoque.EstoqueAtual": {
                required: true
            },
        },
        messages: {
            "estoque.Nome": {
                required: "Campo obrigatório!",
                maxlength: "Máximo 50 Caracteres!"
            },
            "estoque.Categoria": {
                required: "Campo obrigatório!"
            },
            "estoque.PrecoCusto": {
                required: "Campo obrigatório!"
            },
            "estoque.PrecoVenda": {
                required: "Campo obrigatório!"
            },
            "estoque.Descricao": {
                maxlength: "Máximo de 200 Caracteres!"
            },
            "estoque.EstoqueAtual": {
                required: "Campo obrigatório!"
            },
        }
    });
});

//$("#precoVenda").mask("");