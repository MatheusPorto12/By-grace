using ByGrace.Classes;
using ByGrace.IRepositorio;
using ByGrace.Model;
using ByGrace.Model.Cliente;
using ByGrace.Model.Pedido;
using ByGrace.Model.Pedido.Pedido;
using ByGrace.Servicos;
using ByGrace.Servicos.Implementacao;
using ByGrace.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ByGrace.Controllers
{
    public class PedidoController : ControllerBase
    {
        public PedidoController(IRepositorioTrabalho pedidoRepositorio) : base(pedidoRepositorio)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public void SalvarPedido(PedidoIncluirModel objModel)
        {
            PedidoServico pedidoServico = new PedidoServico(Contexto);
            ClienteServico clienteServico = new ClienteServico(Contexto);
            PedidoProdutoServico pedidoProdutoServico = new PedidoProdutoServico(Contexto);
            ProdutosServico produtosServico = new ProdutosServico(Contexto);

            Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

            if (cliente == null)
            {
                RedirectToAction("Index", "/Login");
            }

            Pedido pedido = new Pedido();

            pedido.ValorPedido = objModel.ValorTotalPedido;
            pedido.FormaPagamentoPedido = objModel.FormaPagamento;
            pedido.CodigoClientePedido = cliente.CodigoCliente;
            pedido.SituacaoPedido = Constantes.Constantes.SituacoesPedidos.Realizado;
            pedido.DataPedido = DateTime.Now;
            pedido.BrCodePedido = objModel.BrCodePedido;

            int codigoPedido = pedidoServico.IncluirPedidoProduto(pedido);

            List<PedidoProduto> prodLista = new List<PedidoProduto>();

            foreach (var produtos in objModel.ProdutosLista)
            {
                Produtos prod = produtosServico.ListarPorCodigo(produtos.CodigoProduto);
                prod.QuantidadeProduto = prod.QuantidadeProduto - produtos.QuantidadeProduto;
                produtosServico.Atualizar(prod);

                PedidoProduto pedProd = new PedidoProduto(codigoPedido, produtos.CodigoProduto, produtos.QuantidadeProduto);
                prodLista.Add(pedProd);
                
            }

            pedidoProdutoServico.Incluir(prodLista);
        }

        public void AlterarSituacao(PedidoAtualizarModel objModel)
        {
            PedidoServico pedidoServico = new PedidoServico(Contexto);

            pedidoServico.Atualizar(objModel.pedido);
        }

        public string GerarBrCode(double valor)
        {
            PagamentoServico pagamentoServico = new PagamentoServico(Contexto);

            return pagamentoServico.GerarBrCode(valor).Result;
        }
    }
}
