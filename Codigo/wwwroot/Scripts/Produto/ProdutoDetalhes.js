$("#adicionarCarrinho").click(function () {
    var carrinho = JSON.parse(localStorage.getItem("carrinho"))

    var produto = {
        'CodigoProdutos': $("#idProduto").val(),
        'NomeProduto': $("#nomeProduto").text(),
        'ValorProduto': parseFloat($("#valorProduto").text().replace(/\R/g, "").replace(/\$/g, "").replace(/\ /g, "").replace(/\./g, "").replace(/\,/g, ".")) * $("#quantidade_produto").val(),
        'ValorOriginal': $("#valorProduto").text().replace(/\R/g, "").replace(/\$/g, "").replace(/\ /g, "").replace(/\./g, "").replace(/\,/g, "."),
        'TamanhoProduto': $("#selectTamanho").find(":selected").text(),
        'QuantidadeProduto': $("#quantidade_produto").val(),
        'DescricaoProduto': $("#descricaoProduto").text()
    }

    if (!carrinho.Produtos.find((e) => e.CodigoProdutos == produto.CodigoProdutos)) {
        carrinho.Produtos.push(produto)
        localStorage.setItem('carrinho', JSON.stringify(carrinho))
    }
})

$(".adicionarCarrinho").click(function () {
    var carrinho = JSON.parse(localStorage.getItem("carrinho"))
})

function mask() {
    $(".valorMask").priceFormat({ prefix: "R$ ", centsSeparator: ",", thousandsSeparator: "." });
}

$(document).ready(function () {
    mask()
})