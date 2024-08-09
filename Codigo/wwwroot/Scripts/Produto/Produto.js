$(".deletarProduto").click(function () {

    console.log($(this).attr("data-id"))

    $.ajax({
        url: '/Produto/ExcluirProduto?codigoProduto=' + $(this).attr("data-id"),
        type: "POST",
        success: function (data) {

            location.reload()
            incluirAlert('alert alert-success', data.mensagem)
        },
        error: function (data) {
            incluirAlert('alert alert-danger', data.mensagem);
        }
    });

})

$(document).on("click", ".card_produtos .card-img, .card_produtos .card-body", function () {

    location.href = "/Produto/Detalhes/"+$(this).attr('data-id')

})