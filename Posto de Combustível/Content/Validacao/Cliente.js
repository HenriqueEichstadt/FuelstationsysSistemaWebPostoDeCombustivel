
// Popular combo box de TipoDeVeiculos
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/FabricanteVeiculo/ListaTipoDeVeiculo",
        data: { listaTipoDeVeiculo: $("#listaTipoDeVeiculo").val() },
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (obj) {
            if (obj != null) {
                var data = obj.data;
                var selectbox = $('#listaTipoDeVeiculo');
                selectbox.find('option').remove();
                $('<option>').val("").text("Selecione um tipo").appendTo(selectbox);
                $.each(data, function (i, d) {
                    $('<option>').val(d.Id).text(d.TipoEFabricante).appendTo(selectbox);
                });
            }
        }
    });
});

// Popular combo box de Fabricantes
function PegaFabricantes() {
    $('#listaFabricantes').prop("disabled", false);
    $.ajax({
        type: "GET",
        url: "/FabricanteVeiculo/ListaFabricantes/" + $("#listaTipoDeVeiculo").val(),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (obj) {
            if (obj != null) {
                var data = obj.data;
                var selectbox = $('#listaFabricantes');
                selectbox.find('option').remove();
                $.each(data, function (i, d) {
                    $('<option>').val(d.Id).text(d.TipoEFabricante).appendTo(selectbox);
                });
            }
        }
    });
}


// Validações de Formulário
$(document).ready(function () {
    $("#FormCadastro").validate({
        rules: {
            "cliente.pessoa.Nome": {
                required: true,
                rangelength: [5, 50]
            },
            "cliente.pessoa.Data": {
                required: true
            },
            "cliente.pessoa.Rg": {
                required: true,
                maxlenght: 9
            },
            "cliente.pessoa.CpfeCnpj": {
                required: true,
                maxlength: 14
            },
            "cliente.pessoa.Email": {
                required: true,
                rangelength: [8, 50],
                email: true
            },
            "cliente.pessoa.TelefoneUm": {
                required: true,
                rangelength: [13, 14]
            },
            "cliente.pessoa.TelefoneDois": {
                rangelength: [13, 14]
            },
            "cliente.pessoa.endereco.Cep": {
                required: true,
                maxlength: 9
            },
            "cliente.pessoa.endereco.Rua": {
                required: true,
                maxlength: 100
            },
            "cliente.pessoa.endereco.Numero": {
                required: true,
                maxlength: 7
            },
            "cliente.pessoa.endereco.Bairro": {
                required: true,
                maxlength: 50
            },
            "cliente.pessoa.endereco.Cidade": {
                required: true,
                maxlength: 50
            },
            "cliente.pessoa.endereco.Estado": {
                required: true,
                maxlength: 50
            },
            "cliente.pessoa.endereco.Complemento": {
                maxlength: 50
            },
        },
        messages: {
            "cliente.pessoa.Nome": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 5 a 50 caracteres!"
            },
            "cliente.pessoa.Data": {
                required: "Campo obrigatório!"
            },
            "cliente.pessoa.Rg": {
                required: "Campo obrigatório!",
                maxlenght: "Deve ter no máximo 9 caracteres!"
            },
            "cliente.pessoa.CpfeCnpj": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 14 caracteres!"
            },
            "cliente.pessoa.Email": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 8 a 50 caracteres!",
                email: "Adicione um endereço de email válido!"
            },
            "cliente.pessoa.TelefoneUm": {
                required: "Campo obrigatório!",
                rangelength: "Deve incluir de 13 a 14 caracteres!"
            },
            "cliente.pessoa.TelefoneDois": {
                rangelength: "Deve incluir de 13 a 14 caracteres!"
            },
            "cliente.pessoa.endereco.Cep": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 9 caracteres!"
            },
            "cliente.pessoa.endereco.Rua": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 100 caracteres!"
            },
            "cliente.pessoa.endereco.Numero": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 7 caracteres!"
            },
            "cliente.pessoa.endereco.Bairro": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres!"
            },
            "cliente.pessoa.endereco.Cidade": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres!"
            },
            "cliente.pessoa.endereco.Estado": {
                required: "Campo obrigatório!",
                maxlength: "Deve ter no máximo 50 caracteres!"
            },
            "cliente.pessoa.endereco.Complemento": {
                maxlength: "Deve ter no máximo 50 caracteres!"
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




function limpa_formulario_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('rua').value = ("");
    document.getElementById('bairro').value = ("");
    document.getElementById('cidade').value = ("");
    document.getElementById('estado').value = ("");

}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        document.getElementById('rua').value = (conteudo.logradouro);
        document.getElementById('bairro').value = (conteudo.bairro);
        document.getElementById('cidade').value = (conteudo.localidade);
        document.getElementById('estado').value = (conteudo.uf);
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulario_cep();
        alert("CEP não encontrado.");
        document.getElementById('cep').value = ("");
    }
}

function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep !== "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            document.getElementById('rua').value = "...";
            document.getElementById('bairro').value = "...";
            document.getElementById('cidade').value = "...";
            document.getElementById('estado').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = '//viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            limpa_formulario_cep();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulario_cep();
    }
}

function formatar(mascara, documento) {
    var i = documento.value.length;
    var saida = mascara.substring(0, 1);
    var texto = mascara.substring(i);

    if (texto.substring(0, 1) != saida) {
        documento.value += texto.substring(0, 1);
    }

}

function idade() {
    var data = document.getElementById("dtnasc").value;
    var dia = data.substr(0, 2);
    var mes = data.substr(3, 2);
    var ano = data.substr(6, 4);
    var d = new Date();
    var ano_atual = d.getFullYear(),
        mes_atual = d.getMonth() + 1,
        dia_atual = d.getDate();

    ano = +ano,
        mes = +mes,
        dia = +dia;

    var idade = ano_atual - ano;

    if (mes_atual < mes || mes_atual == mes_aniversario && dia_atual < dia) {
        idade--;
    }
    return idade;
}


function exibe(i) {



    document.getElementById(i).readOnly = true;




}

function desabilita(i) {

    document.getElementById(i).disabled = true;
}

function habilita(i) {
    document.getElementById(i).disabled = false;
}


