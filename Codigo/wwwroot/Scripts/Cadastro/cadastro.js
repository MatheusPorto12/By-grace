$(".submit_btn").click(function () {
    var cliente = new Object()
    cliente.CodigoCliente = null
    cliente.EmailCliente = $('#email').val()
    cliente.CpfCliente = $('#cpf').val()
    cliente.TelefoneCliente = $('#telefone').val()
    cliente.NascimentoCliente = $('#data_nascimento').val()
    cliente.NomeCliente = $('#nome').val()
    cliente.SenhaCliente = $('#senhaConfirm').val()
    cliente.TipoCliente = 1
    cliente.DataCadastro = null


    $.ajax({
        url: `/Cadastro/Cadastrar`,
        type: "POST",
        data: cliente,
        success: function (data) {
            console.log(data)
            location.href = "/Login"
        },
        error: function (data) {
            console.log(data)
        }
    });
})