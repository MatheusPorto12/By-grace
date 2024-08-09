$(document).on('click', "#AlterarCliente", function () {
    var objCliente = new Object();

    if ($("#senhaConfirm").val() == $("#senha").val()) {
        objCliente.codigoCliente = $("#codigoClienteLogado").val()
        objCliente.nomeCliente = $("#nome").val()
        objCliente.cpfCliente = $("#cpf").val()
        objCliente.telefoneCliente = $("#telefone").val()
        objCliente.nascimentoCliente = $("#data_nascimento").val()
        objCliente.emailCliente = $("#email").val()
        objCliente.senhaCliente = $("#senhaConfirm").val()
    }

    $.ajax({
        url: '/Usuario/AlterarCliente',
        method: 'POST',
        data: objCliente,
        success: function () {
            window.location.reload()
        }
    })
})

