$("#salvarProduto").click(function () {

    var objModelProduto = new Object()

    objModelProduto.CodigoProduto = $("#idProduto").val() ? $("#idProduto").val() : 0;
    objModelProduto.NomeProduto = $("#nomeProduto").val()
    objModelProduto.DescricaoProduto = $("#descricaoProduto").val()
    objModelProduto.TamanhoProduto = $("#selectTamanho :selected").val()
    objModelProduto.ValorProduto = $("#valorProduto").val().replace(/\R/g, "").replace(/\$/g, "").replace(/\ /g, "").replace(/\./g, "").replace(/\,/g, ".")
    objModelProduto.QuantidadeProduto = $("#qtdProduto").val()
    objModelProduto.CategoriaProduto = $("#selectCategoria :selected").val()
    objModelProduto.DisponivelProduto = $("#disponivelProduto").val() == '' ? 'false' : $("#disponivelProduto").val()
    /*objModelProduto.FotoProduto = $("#fotoProduto").attr('data-foto')*/

    var formData = new FormData();

    formData.append('imageFile', $('#fileFoto')[0].files[0]);
    formData.append('Produto.CodigoProduto', objModelProduto.CodigoProduto);
    formData.append('Produto.NomeProduto', objModelProduto.NomeProduto);
    formData.append('Produto.DescricaoProduto', objModelProduto.DescricaoProduto);
    formData.append('Produto.TamanhoProduto', objModelProduto.TamanhoProduto);
    formData.append('Produto.ValorProduto', objModelProduto.ValorProduto);
    formData.append('Produto.QuantidadeProduto', objModelProduto.QuantidadeProduto);
    formData.append('Produto.CategoriaProduto', objModelProduto.CategoriaProduto);
    formData.append('Produto.DisponivelProduto', objModelProduto.DisponivelProduto);

    $.ajax({
        url: '/Produto/SalvarProduto',
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {

            window.location.href = '/Produto'
            incluirAlert('alert alert-success', data.mensagem, true, false);
        },
        error: function (data) {

            incluirAlert('alert alert-danger', data.mensagem);

        }
    });

})

function mask() {
    $(".valorMask").priceFormat({ prefix: "R$ ", centsSeparator: ",", thousandsSeparator: "." });
}

$(document).ready(function () {

    if ($("#idProduto").val()) {

        $("#selectTamanho option.selected").attr('selected', 'true');
        $("#selectCategoria option.selected").attr('selected', 'true');

    }

    mask()
    startSwitchery('.js-switch', '#CA696A');  

})

$("#fotoProduto").click(function () {

    $("#fileFoto").trigger('click')

})

$("#fileFoto").change(function (foto) {

    readURL(this);

})

function readURL(input) {

    if (input.files && input.files[0]) {
      var reader = new FileReader();
  
      reader.onload = function (e) {
        $('#fotoExibida').attr('src', e.target.result);
      };
  
      reader.readAsDataURL(input.files[0]);
    }
  }

function startSwitchery(elemento, cor) {

    elemento = elemento == "" || elemento == undefined ? ".js-switch" : elemento;
    cor = cor == "" || cor == undefined ? "#ebaa4b" : cor;
    
    // removeSwitchery();

    var elems = Array.prototype.slice.call(document.querySelectorAll(elemento));    
    elems.forEach(function (n) {
        var t = new Switchery(n, { color: cor });
    });
    $(elemento).change(function () { $(this).val(this.checked); });
}

//$("#fileFoto").change(function (foto) {
//    var arquivo = foto.target.files[0];
//    var reader = new FileReader();

//    reader.onload = (function (e) {
//        var arrayDeBytes = new Uint8Array(e.target.result);
//        $("#fotoProduto").attr('data-foto', arrayDeBytes);
//    });

//    reader.readAsArrayBuffer(arquivo);

    
//})
