
$(document).ready(function () {
    $("#FormCadastro").validate({
        rules: {
            "funcionario.Cargo": {
                required: true
            },
            "funcionario.NivelAcesso": {
                required: true
            },
            "funcionario.pessoa.Nome": {
                rangelength: [5, 50]
            },
            "funcionario.pessoa.Data": {
                required: true
            },
            "funcionario.pessoa.Rg": {
                required: true,
                maxlenght: 9
            },
            "funcionario.pessoa.CpfeCnpj": {
                required: true,
                maxlength: 14
            },
            "funcionario.pessoa.Email": {
                required: true,
                rangelength: [8, 50],
                email: true
            },
            "funcionario.pessoa.TelefoneUm": {
                required: true,
                rangelength: [13, 14]
            },
            "funcionario.pessoa.TelefoneDois": {
                rangelength: [13, 14]
            },
            "funcionario.pessoa.endereco.Cep": {
                required: true,
                maxlength: 9
            },
            "funcionario.pessoa.endereco.Rua": {
                required: true,
                maxlength: 100
            },
            "funcionario.pessoa.endereco.Numero": {
                required: true,
                maxlength: 7
            },
            "funcionario.pessoa.endereco.Bairro": {
                required: true,
                maxlength: 50
            },
            "funcionario.pessoa.endereco.Cidade": {
                required: true,
                maxlength: 50
            },
            "funcionario.pessoa.endereco.Estado": {
                required: true,
                maxlength: 50
            },
            "funcionario.pessoa.endereco.Complemento": {
                maxlength: 50
            },
            "funcionario.NomeUsuario": {
                required: true,
                rangelength: [8, 20]
            },
            "funcionario.Senha": {
                required: true,
                rangelength: [8, 20]
            },
            repitasenha: {
                equalTo: "#senhaPrincipal"
            },
        },
        messages: {
            "funcionario.Cargo": {
                required: "Campo obrigatório!"
            },
            "funcionario.NivelAcesso": {
                required: "Campo obrigatório!"
            },
            "funcionario.pessoa.Nome": {
                rangelength: "Deve incluir de 5 a 50 caracteres!"
            },
            "funcionario.pessoa.Data": {
                required: "Campo obrigatório!"
            },
            "funcionario.pessoa.Rg": {
                required: "Campo obrigatório!",
                maxlenght: "Deve ter no máximo 9 caracteres!"
            },
            "funcionario.pessoa.CpfeCnpj": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 14 caracteres!"
            },
            "funcionario.pessoa.Email": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 8 a 50 caracteres!",
                email: "Adicione um endereço de email válido!"
            },
            "funcionario.pessoa.TelefoneUm": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 13 a 14 caracteres!"
            },
            "funcionario.pessoa.TelefoneDois": {
                rangelength: "Deve incluir de 13 a 14 caracteres!"
            },
            "funcionario.pessoa.endereco.Cep": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 9 caracteres!"
            },
            "funcionario.pessoa.endereco.Rua": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 100 caracteres!"
            },
            "funcionario.pessoa.endereco.Numero": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 7 caracteres!"
            },
            "funcionario.pessoa.endereco.Bairro": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres!"
            },
            "funcionario.pessoa.endereco.Cidade": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres!"
            },
            "funcionario.pessoa.endereco.Estado": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres!"
            },
            "funcionario.pessoa.endereco.Complemento": {
                maxlength: "Deve ter no máximo 50 caracteres!"
            },
            "funcionario.NomeUsuario": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 8 a 20 caracteres!"
            },
            "funcionario.Senha": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 8 a 20 caracteres!"
            },
            repitasenha: {
                equalTo: "As senhas diferem!"
            },
        }
    });
});

$("#CpfeCnpj").mask("000.000.000-00");
$("#telefoneUm").mask("(00)00000-0000");
$("#telefoneDois").mask("(00)00000-0000");
$("#Cep").mask("00000-000");
$("#Rg").mask("0.000.000.000");


// Função para conferir se o CPF é válido ou não
confereCPF = function (el) {
    document.getElementById('cpfFrase').innerHTML = validarCPF(el.value) ? '<span style="color:green">CPF Válido!</span>' : '<span style="color:red">CPF Inválido!</span>';
    if (el.value == '') document.getElementById('cpfFrase').innerHTML = '';
}


function validarCPF(cpf) {
    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf == '') return false;
    // Elimina CPFs invalidos conhecidos	
    if (cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999")
        return false;
    // Valida 1o digito	
    add = 0;
    for (i = 0; i < 9; i++)
        add += parseInt(cpf.charAt(i)) * (10 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(9)))
        return false;
    // Valida 2o digito	
    add = 0;
    for (i = 0; i < 10; i++)
        add += parseInt(cpf.charAt(i)) * (11 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(10)))
        return false;
    return true;
}