
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
                maxlength: 18
            },
            "pessoa.TelefoneUm": {
                required: true,
                rangelength: [13, 14]
            },
            "pessoa.TelefoneDois": {
                rangelength: [13, 14]
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
                maxlength: 9
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
                maxlength: "Deve ter no máximo 18 caracteres!"
            },
            "pessoa.TelefoneUm": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 13 a 14 caracteres!"
            },
            "pessoa.TelefoneDois": {
                rangelength: "Deve incluir de 13 a 13 caracteres!"
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
                maxlength: "Deve ter no máximo 9 caracteres"
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