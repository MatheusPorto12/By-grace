function getClienteData() {
    $.ajax({
        url: '/Usuario/getClienteLogado',
        method: 'GET',
        async: true,
        success: function (data) {
            console.log(data)
            $("#codigoClienteLogado").val(data.cliente.codigoCliente)
            $("#nome").val(data.cliente.nomeCliente)
            $("#cpf").val(data.cliente.cpfCliente)
            $("#telefone").val(data.cliente.telefoneCliente)
            console.log(data.cliente.nascimentoCliente)

            const getDateFromString = str => {
                const [date, time] = str.split(" ");
                str = `${date}`
                return new Date(str);
            };
            let date = getDateFromString(data.cliente.nascimentoCliente);

            var date2 = new Date(date);

            function pad(num) {
                return (num < 10 ? '0' : '') + num;
            }

            var year = date2.getFullYear();
            var month = pad(date2.getMonth() + 1);
            var day = pad(date2.getDate());

            var formattedDate = year + '-' + month + '-' + day;

            $("#data_nascimento").val(formattedDate)
            $("#email").val(data.cliente.emailCliente)
            $("#senha").val(data.cliente.senhaCliente)
            $("#senhaConfirm").val(data.cliente.senhaCliente)
        }
    })
}
$(document).ready(function () {
    $.ajax({
        url: '/Usuario/Alterar',
        async: true,
        success: function (data) {
            $("#pageContent").empty()
            $("#pageContent").append(data)


            getClienteData()
        }
    })
})

$(document).on('click', '#pedidosUsuario', function () {
    $.ajax({
        url: '/Usuario/Pedidos',
        method: 'GET',
        async: true,
        success: function (data) {
            $("#pageContent").empty()
            $("#pageContent").append(data)
        }
    })
})

$(document).on('click', '#alterarUsuario', function () {
    $.ajax({
        url: '/Usuario/Alterar',
        method: 'GET',
        async: true,
        success: function (data) {
            $("#pageContent").empty()
            $("#pageContent").append(data)

            getClienteData()
        }
    })
})

$(document).on('click', '#indicadoresGerais', function () {
    $.ajax({
        url: '/Usuario/Indicadores',
        method: 'GET',
        async: true,
        success: function (data) {
            $("#pageContent").empty()
            $("#pageContent").append(data)

            getClienteData()
        }
    })
})