
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

//function formatar(mascara, documento) {
//    var i = documento.value.length;
//    var saida = mascara.substring(0, 1);
//    var texto = mascara.substring(i);

//    if (texto.substring(0, 1) != saida) {
//        documento.value += texto.substring(0, 1);
//    }

//}

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

