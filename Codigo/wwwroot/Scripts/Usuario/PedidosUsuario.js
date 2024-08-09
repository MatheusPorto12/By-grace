$(document).on('click', '.hidabble', (e) => {
    console.log($(e.target).parents().next(".rowToHide"))
    $(e.target).parents().next('.rowToHide').toggle(500);
})

$(document).on('change', '.selectStatusPedido', (e) => {
    var objModelPedido = new Object()

    console.log($(e.target).attr("data-id"))

    var id = $(e.target).attr('data-id')
    objModelPedido.CodigoPedido = id
    objModelPedido.CodigoClientePedido = $(`#codigoClientePedido_${id}`).text()
    objModelPedido.ValorPedido = $(`#valorPedido_${id}`).text().replace("R$", "")
    objModelPedido.FormaPagamentoPedido = 0
    objModelPedido.SituacaoPedido = $(`#selectStatusPedido_${id} :selected`).val()

    var objModel = new Object()

    objModel.pedido = objModelPedido

    $.ajax({
        url: '/Pedido/AlterarSituacao',
        type: 'POST',
        data: objModel,
        success: function (data) {

            window.location.reload()
            incluirAlert('alert alert-success', data.mensagem, true, false);
        }
    })
})