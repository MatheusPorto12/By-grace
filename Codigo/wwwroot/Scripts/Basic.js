function removeAlert() {
    $("#alertaSistema").hide(1000)
    $("#alertaSistema").attr('class', '')
    $("#alertaSistema").attr('class', 'mb-3')
    $("#alertaSistema").text("")

}

function incluirAlert(classe, mensagem) {
    $("#alertaSistema").show(1000)
    $("#alertaSistema").attr('class', classe)
    $("#alertaSistema").text(mensagem)

    setTimeout(() => {
        removeAlert();
    }, 5000)
}

function limitarExibicaoCaracteres(texto, quantidade) {
    // $(".limit").each(function (i) {
    var text = texto;
    var len = text.length;
    if (len > quantidade) {
        var query = text.split(" ", 10);
        query.push('...');
        res = query.join(' ');
        texto.text(res);
    }
    //  });
}