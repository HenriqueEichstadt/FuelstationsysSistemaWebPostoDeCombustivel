
$(document).ready(function () {
    $("#FormCadastro").validate({
        rules: {
            "fornecedor.Nome": {
                rangelength: [5, 50]
            },
            "fornecedor.NomeFantasia": {

                required: true,
                rangelength: [5, 50]
            },
            "fornecedor.NomeRazaoSocial": {
                required: true,
                rangelength: [5, 50]
            },
            "fornecedor.InscricaoEstadual": {
                required: true,
                rangelength: [8, 10]
            },
            "fornecedor.CpfeCnpj": {
                required: true,
                maxlength: 18
            },
            "fornecedor.TelefoneUm": {
                required: true,
                rangelength: [13, 14]
            },
            "fornecedor.TelefoneDois": {
                rangelength: [13, 14]
            },
            "fornecedor.Email": {
                required: true,
                rangelength: [8, 50],
                email: true
            },
            "fornecedor.Observacoes": {
                maxlength: 200
            },
            "fornecedor.endereco.Cep": {
                required: true,
                maxlength: 9
            },
            "fornecedor.endereco.Rua": {
                required: true,
                maxlength: 100
            },
            "fornecedor.endereco.Numero": {
                required: true,
                maxlength: 7
            },
            "fornecedor.endereco.Bairro": {
                required: true,
                maxlength: 50
            },
            "fornecedor.endereco.Cidade": {
                required: true,
                maxlength: 50
            },
            "fornecedor.endereco.Estado": {
                required: true,
                maxlength: 50
            },
        },
        messages: {
            "fornecedor.Nome": {
                rangelength: "Deve incluir de 5 a 50 caracteres!"
            },
            "fornecedor.NomeFantasia": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 5 a 50 caracteres!"
            },
            "fornecedor.NomeRazaoSocial": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 5 a 50 caracteres!"
            },
            "fornecedor.InscricaoEstadual": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 8 a 10 caracteres!"
            },
            "fornecedor.CpfeCnpj": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 18 caracteres!"
            },
            "fornecedor.TelefoneUm": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 13 a 14 caracteres!"
            },
            "fornecedor.TelefoneDois": {
                rangelength: "Deve incluir de 13 a 13 caracteres!"
            },
            "fornecedor.Email": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 8 a 50 caracteres!",
                email: "Adicione um endereço de email válido!"

            },
            "fornecedor.Observacoes": {
                maxlength: "Deve ter no máximo 200 caracteres"
            },
            "fornecedor.endereco.Cep": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 9 caracteres"
            },
            "fornecedor.endereco.Rua": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 100 caracteres"
            },
            "fornecedor.endereco.Numero": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 7 caracteres"
            },
            "fornecedor.endereco.Bairro": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres"
            },
            "fornecedor.endereco.Cidade": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres"
            },
            "fornecedor.endereco.Estado": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres"
            },
        }
    });
});

$("#CpfeCnpj").mask("00.000.000/0000-00");
$("#telefoneUm").mask("(00)00000-0000");
$("#telefoneDois").mask("(00)00000-0000");
$("#Cep").mask("00000-000");


// Função para conferir se o CNPJ é válido ou não
confereCNPJ = function (el) {
    document.getElementById('cnpjFrase').innerHTML = Valida_Cnpj(el.value) ? '<span style="color:green">CNPJ Válido!</span>' : '<span style="color:red">CNPJ Inválido!</span>';
    if (el.value == '') document.getElementById('cnpjFrase').innerHTML = '';
}

function Valida_Cnpj(c) {
    var b = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

    if ((c = c.replace(/[^\d]/g, "")).length != 14)
        return false;

    if (/0{14}/.test(c))
        return false;

    for (var i = 0, n = 0; i < 12; n += c[i] * b[++i]);
    if (c[12] != (((n %= 11) < 2) ? 0 : 11 - n))
        return false;

    for (var i = 0, n = 0; i <= 12; n += c[i] * b[i++]);
    if (c[13] != (((n %= 11) < 2) ? 0 : 11 - n))
        return false;

    return true;
}