$(document).ready(() => {
    var carrinho = JSON.parse(localStorage.getItem("carrinho"))
    var produtos = carrinho.Produtos
    var total = 0.00

    for (var i = 0; i < carrinho.Produtos.length; i++) {
        total += parseFloat(produtos[i].ValorProduto)
        $("#lista_produtos").append(
            `<div class="row" style="height: 14vh; margin-bottom: 10px; border: 1px solid #ca696a; border-radius: 11px; ">
                <div class="col-md-4" style="text-align: center; padding: 0; background-color: transparent; ">
                    <img src="/Produto/ObterImagem/${produtos[i].CodigoProdutos}" style="width: 100%; height: 13.8vh; border-radius: 10px 0 0 10px; object-fit: cover;" id="imagem_produto"></img>
                 </div >
                <div id="DetalhesProdutoPedido" style="background-color: transparent" class="col-md-8 DetalhesProdutoPedido DetalhesProdutoPedido_${i+1}" data-codigo="${produtos[i].CodigoProdutos}">
                    <div id="nome_produto_div">
                        <span id="nome_produto_${i+1}">${produtos[i].NomeProduto}</span>
                    </div>
                    <div id="quantidade_produto_div">
                        <span>Quantidade: <span id="quantidade_produto_${i + 1}">${produtos[i].QuantidadeProduto}</span></span>
                    </div>
                    <div id="tamanho_produto_div">
                        <span id="tamanho_produto_${i+1}">${produtos[i].TamanhoProduto}</span>
                    </div>
                    <div id="valor_produto_div">
                        <span id="valor_produto_${i+1}" style="color: #fff; padding: 7px; background-color: #ca696a; border-radius: 10px">R$ ${produtos[i].ValorProduto.toString().padEnd(produtos[i].ValorProduto.toString().indexOf('.')+3, '0')}</span>
                    </div>
                </div>
            </div`
        )
    }

    $("#valor_pedido").text(total.toFixed(2))

    
})

$(document).on('click', "#finalizarPedido", function () {
    qrCodePix($("#valor_pedido").text())
})

async function qrCodePix(valor){
    $.ajax({
        url: '/Pedido/GerarBrCode?valor=' + valor,
        type: 'GET',
        async: true,
        success: function (data) {

            $("#qrcodepix").attr('src', "https://gerarqrcodepix.com.br/api/v1?brcode="+data)+"&tamanho=256"
            $("#brcode").text(data)
            $("#finalizarPedido").attr('disabled', 'true')
            $("#finalizarPedido").text('Por favor, realize o pagamento')
            SalvarPedido()
        }
    })
}

function SalvarPedido() {
    var arrayProdutos = []

    var objModel = new Object()

    for (var i = 0; i < $('.DetalhesProdutoPedido').length; i++) {

        var objPostProdutos = new Object()

        objPostProdutos.CodigoProduto = $(`.DetalhesProdutoPedido_${i + 1}`).attr('data-codigo')
        objPostProdutos.NomeProduto = $(`#nome_produto_${i + 1}`).text()
        objPostProdutos.TamanhoProduto = $(`#tamanho_produto_${i + 1}`).text()
        objPostProdutos.QuantidadeProduto = $(`#quantidade_produto_${i + 1}`).text()
        objPostProdutos.ValorProduto = $(`#valor_produto_${i + 1}`).text().replace(',', '.')

        arrayProdutos.push(objPostProdutos)

    }

    objModel.ProdutosLista = arrayProdutos
    objModel.ValorTotalPedido = $("#valor_pedido").text()
    objModel.FormaPagamento = 1     //0 = Cartão de Crédito 1 = Pix 2 = Dinheiro
    objModel.BrCodePedido = $("#brcode").text()

    $.ajax({
        url: '/Pedido/SalvarPedido',
        type: "POST",
        data: objModel,
        success: function (data) {
            console.log(data)
        },
        error: function (data) {
            window.location.href = '/Login'
            incluirAlert('alert alert-danger', data.mensagem);

        }
    });
}