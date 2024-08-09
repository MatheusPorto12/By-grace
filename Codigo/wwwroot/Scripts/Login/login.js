$("#btn_login").click(function () {
    $.ajax({
        url: `/Login/logar`,
        type: "GET",
        contentType: 'application/json',
        dataType: 'json',
        data: {
            'email': $('#emailInput').val(),
            'senha': $('#senhaInput').val()
        },
        success: function (data) {
            if (data.cliente.cpfCliente == null) {
                location.href = "/Login"
            } else {
                var prods = JSON.parse(localStorage.getItem("carrinho"))

                if (prods == null || prods.Produtos.lenght == 0) {
                    localStorage.setItem("carrinho", `{"codigoCliente": ${data.cliente.codigoCliente}, "Produtos": []}`)
                } else {
                    prods.codigoCliente = data.cliente.codigoCliente
                    localStorage.setItem("carrinho", JSON.stringify(prods))
                }
                location.href = "/Produto"
            }
        }
    });
})

function toggleEye() {
    var x = document.getElementById("senhaInput");
    var eyeIcon = document.getElementById("eyeIcon");
    if (x.type === "password") {
        x.type = "text";
        eyeIcon.classList.remove("eye-open");
        eyeIcon.classList.add("eye-closed");
    } else {
        x.type = "password";
        eyeIcon.classList.remove("eye-closed");
        eyeIcon.classList.add("eye-open");
    }
}

