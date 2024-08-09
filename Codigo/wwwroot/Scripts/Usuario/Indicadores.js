$(document).on('change', '#seletorAno', function () {
    var anoBase = $("#seletorAno :selected").val();

    google.charts.load("current", { packages: ['corechart'] });
    google.charts.setOnLoadCallback(drawChartVGV);

    $.ajax({
        url: '/Indicador/ValorGeralVendasPorAno?anoReferencia=' + anoBase,
        method: 'GET',
        async: true,
        success: function (data) {
            var arrayMeses = data;
            console.log(arrayMeses)
            drawChartVGV(arrayMeses);
        }
    })

    /*google.charts.setOnLoadCallback(drawChartCrescimentoBaseClientes);*/
    $.ajax({
        url: '/Indicador/CrescimentoCadatroClientePorAno?anoReferencia=' + anoBase,
        method: 'GET',
        async: true,
        success: function (data) {
            var arrayMeses = data;
            drawChartCrescimentoBaseClientes(arrayMeses);
        }
    })

    /*google.charts.setOnLoadCallback(drawChartQuantidadeDeVendasPorMes);*/
    $.ajax({
        url: '/Indicador/QuantidadeDeVendasPorAno?anoReferencia=' + anoBase,
        method: 'GET',
        async: true,
        success: function (data) {
            var arrayMeses = data;
            drawChartQuantidadeDeVendasPorMes(arrayMeses);
        }
    })

    
})

function drawChartVGV(arrayMeses) {
    var data = google.visualization.arrayToDataTable([
        ["Meses", "Valor", { role: "style" }],
        ["Janeiro", arrayMeses[0], "#ca696a"],
        ["Fevereiro", arrayMeses[1], "#ca696a"],
        ["Março", arrayMeses[2], "#ca696a"],
        ["Abril", arrayMeses[3], "#ca696a"],
        ["Maio", arrayMeses[4], "#ca696a"],
        ["Junho", arrayMeses[5], "#ca696a"],
        ["Julho", arrayMeses[6], "#ca696a"],
        ["Agosto", arrayMeses[7], "#ca696a"],
        ["Setembro", arrayMeses[8], "#ca696a"],
        ["Outubro", arrayMeses[9], "#ca696a"],
        ["Novembro", arrayMeses[10], "#ca696a"],
        ["Dezembro", arrayMeses[11], "#ca696a"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
        {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation",
            animation: {
                startup: true,
                duration: 1000,
                easing: 'out'
            }
        },
        2]);

    var options = {
        title: "Valor geral de vendas",
        width: returnRelativeWidth(200),
        height: 400,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("indicadorVGV"));
    chart.draw(view, options);
}

function drawChartCrescimentoBaseClientes(arrayMeses) {
    var data = google.visualization.arrayToDataTable([
        ["Meses", "Novos clientes", { role: "style" }],
        ["Janeiro", arrayMeses[0], "#ca696a"],
        ["Fevereiro", arrayMeses[1], "#ca696a"],
        ["Março", arrayMeses[2], "#ca696a"],
        ["Abril", arrayMeses[3], "#ca696a"],
        ["Maio", arrayMeses[4], "#ca696a"],
        ["Junho", arrayMeses[5], "#ca696a"],
        ["Julho", arrayMeses[6], "#ca696a"],
        ["Agosto", arrayMeses[7], "#ca696a"],
        ["Setembro", arrayMeses[8], "#ca696a"],
        ["Outubro", arrayMeses[9], "#ca696a"],
        ["Novembro", arrayMeses[10], "#ca696a"],
        ["Dezembro", arrayMeses[11], "#ca696a"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
        {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation",
            animation: {
                startup: true,
                duration: 1000,
                easing: 'out'
            }
        },
        2]);

    var options = {
        title: "Crescimento da base de clientes",
        width: returnRelativeWidth(200),
        height: 400,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("indicadorCrescimentoCadastro"));
    chart.draw(view, options);
}

function drawChartQuantidadeDeVendasPorMes(arrayMeses) {
    var data = google.visualization.arrayToDataTable([
        ["Meses", "Vendas", { role: "style" }],
        ["Janeiro", arrayMeses[0], "#ca696a"],
        ["Fevereiro", arrayMeses[1], "#ca696a"],
        ["Março", arrayMeses[2], "#ca696a"],
        ["Abril", arrayMeses[3], "#ca696a"],
        ["Maio", arrayMeses[4], "#ca696a"],
        ["Junho", arrayMeses[5], "#ca696a"],
        ["Julho", arrayMeses[6], "#ca696a"],
        ["Agosto", arrayMeses[7], "#ca696a"],
        ["Setembro", arrayMeses[8], "#ca696a"],
        ["Outubro", arrayMeses[9], "#ca696a"],
        ["Novembro", arrayMeses[10], "#ca696a"],
        ["Dezembro", arrayMeses[11], "#ca696a"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
        {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation",
            animation: {
                startup: true,
                duration: 1000,
                easing: 'out'
            }
        },
        2]);

    var options = {
        title: "Vendas por mês",
        width: returnRelativeWidth(200),
        height: 400,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("indicadorVendasPorMes"));
    chart.draw(view, options);
}

function returnRelativeWidth(valor) {
    return document.width * valor / 100;
}