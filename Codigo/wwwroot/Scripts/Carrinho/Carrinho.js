
$(document).on('click', "#deleteProduto", function (e) {
  e.stopImmediatePropagation()
  var id = $(this).attr('data-id');

  $(`#cliente-cart #${id}`).hide(300).remove()

  var carrinho = JSON.parse(localStorage.getItem("carrinho"))
  var produtos = carrinho.Produtos
  var index = produtos.map(e => e.CodigoProdutos).indexOf(id)
  produtos.splice(index, 1)

  carrinho.Produtos = produtos
  localStorage.setItem("carrinho", JSON.stringify(carrinho))
})

//Open and list shopping cart
$("#opencart").hover(() => {
  var carrinho = JSON.parse(localStorage.getItem("carrinho"))
  var produtos = carrinho.Produtos

  //Display info message on cart list
  if (produtos.length == 0) {
      $("#mensagem_info_carrinho").show()
      $("#mensagem_info_carrinho").text("Carrinho parece estar vazio, tente adicionar algo :)")
      $("#finalizar_pedido_carrinho").hide()
  } else {
      $("#mensagem_info_carrinho").hide()
      $("#finalizar_pedido_carrinho").show()

      //Remove the itens on the cart to counter duplicity
      $(".item").remove()
      $(".cart-listing").remove()

      var totalCart = 0.00

      //generate cart products listing
      for (var i = 0; i < carrinho.Produtos.length; i++) {
          totalCart += parseFloat(carrinho.Produtos[i].ValorProduto)
          var element = `<div class="item">
              <div class="buttons">
                <span id="deleteProduto" data-id="${carrinho.Produtos[i].CodigoProdutos}" class="delete-btn"></span>
              </div>

              <div class="description">
                <span>${carrinho.Produtos[i].NomeProduto}</span>
              </div>

              <div class="quantity">
                <input class="product_qtd" data-id="${carrinho.Produtos[i].CodigoProdutos}" type="text" name="name" value="${carrinho.Produtos[i].QuantidadeProduto}">
              </div>

              <div id="total-price_${carrinho.Produtos[i].CodigoProdutos}" class="total-price">R$ ${carrinho.Produtos[i].ValorProduto.toString().padEnd(carrinho.Produtos[i].ValorProduto.toString().indexOf('.')+3, '0')}</div>
            </div>`

          $("#cart_area").append(`<li id="${carrinho.Produtos[i].CodigoProdutos}" class='scroll-to-section cart-listing'>${element}</li>`)
          $("#cart_total_itens_price").text(`R$ ${totalCart.toString().padEnd(totalCart.toString().indexOf('.')+3, '0')}`)

      }
  }
})

$(document).on('change', '.product_qtd', function (e) {
  e.stopImmediatePropagation()
  var carrinho = JSON.parse(localStorage.getItem("carrinho"))
  var produtos = carrinho.Produtos

  var id = $(this).attr('data-id')
  var valor = parseFloat(produtos.find(e => e.CodigoProdutos == id).ValorOriginal).toFixed(2)
  var qtd = $(this).val()

  valor = parseFloat(valor) * qtd

  produtos.find(e => e.CodigoProdutos == id).ValorProduto = valor
  produtos.find(e => e.CodigoProdutos == id).QuantidadeProduto = qtd

  $(`#total-price_${id}`).text(`R$ ${valor}`)

  var valorTotal = 0.00

  for (var i = 0; i < produtos.length; i++) {
      valorTotal += produtos[i].ValorProduto
  }

  $("#cart_total_itens_price").text(`R$ ${valorTotal.toString().padStart(2, '0')}`)

  carrinho.Produtos = produtos

  localStorage.setItem("carrinho", JSON.stringify(carrinho))
})