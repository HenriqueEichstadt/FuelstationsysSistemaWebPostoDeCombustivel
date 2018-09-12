
$(document).ready(function () {
    $("#FormCadastro").validate({
        rules: {
            "pessoa.Nome": {
                rangelength: [5, 50]
            },
            "pessoa.NomeFantasia": {
                required: true,
                rangelength: [5, 50]
            },
            "pessoa.NomeRazaoSocial": {
                required: true,
                rangelength: [5, 50]
            },
            "pessoa.InscricaoEstadual": {
                required: true,
                rangelength: [8, 10]
            },
            "pessoa.CpfeCnpj": {
                required: true,
                rangelength: [11, 14],
                digits: true
            },
            "pessoa.TelefoneUm": {
                required: true,
                rangelength: [9, 11]
            },
            "pessoa.TelefoneDois": {
                required: false,
                rangelength: [9, 11]
            },
            "pessoa.Email": {
                required: true,
                rangelength: [8, 50],
                email: true
            },
            "pessoa.Observacoes": {
                maxlength: 200
            },
            "pessoa.endereco.Cep": {
                required: true,
                maxlength: 8
            },
            "pessoa.endereco.Rua": {
                required: true,
                maxlength: 100
            },
            "pessoa.endereco.Numero": {
                required: true,
                maxlength: 7
            },
            "pessoa.endereco.Bairro": {
                required: true,
                maxlength: 50
            },
            "pessoa.endereco.Cidade": {
                required: true,
                maxlength: 50
            },
            "pessoa.endereco.Estado": {
                required: true,
                maxlength: 50
            },
            "pessoa.endereco.Complemento": {
                maxlength: 50
            }
        },
        messages: {
            "pessoa.Nome": {
                rangelength: "Deve incluir de 5 a 50 caracteres!"
            },
            "pessoa.NomeFantasia": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 5 a 50 caracteres!"
            },
            "pessoa.NomeRazaoSocial": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 5 a 50 caracteres!"
            },
            "pessoa.InscricaoEstadual": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 8 a 10 caracteres!"
            },
            "pessoa.CpfeCnpj": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 11 a 14 caracteres!",
                digits: "Deve conter apenas números!"
            },
            "pessoa.TelefoneUm": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 9 a 11 caracteres!"
            },
            "pessoa.TelefoneDois": {
                rangelength: "Deve incluir de 9 a 11 caracteres!"
            },
            "pessoa.Email": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 8 a 50 caracteres!",
                email: "Adicione um endereço de email válido!"

            },
            "pessoa.Observacoes": {
                maxlength: "Deve ter no máximo 200 caracteres"
            },
            "pessoa.endereco.Cep": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 8 caracteres"
            },
            "pessoa.endereco.Rua": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 100 caracteres"
            },
            "pessoa.endereco.Numero": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 7 caracteres"
            },
            "pessoa.endereco.Bairro": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres"
            },
            "pessoa.endereco.Cidade": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres"
            },
            "pessoa.endereco.Estado": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres"
            },
            "pessoa.endereco.Complemento": {
                maxlength: "Deve ter no máximo 50 caracteres"
            }
        }
    });
});

