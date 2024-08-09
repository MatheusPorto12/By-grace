using ByGrace.Classes;
using ByGrace.IRepositorio;
using ByGrace.Model;
using ByGrace.Servicos.Implementacao;
using ByGrace.Servicos;
using Microsoft.AspNetCore.Mvc;
using ByGrace.Constantes;
using ByGrace.Model.Pedido;
using ByGrace.Classes.Comum;
using ByGrace.Servicos.Interfaces;
using ByGrace.Model.Indicadores;

namespace ByGrace.Controllers
{
    public class UsuarioController : ControllerBase
    {
        public UsuarioController(IRepositorioTrabalho usuarioRepositorio) : base(usuarioRepositorio)
        {
        }

        public IActionResult Index()
        {
            ClienteServico clienteServico = new ClienteServico(Contexto);
            Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

            if (cliente == null)
            {
                return RedirectToAction("Index", "/Login");
            }

            ClienteModel objModel = new ClienteModel();

            objModel.cliente = cliente;

            return View(objModel);
        }

        public JsonResult getClienteLogado()
        {
            ClienteServico clienteServico = new ClienteServico(Contexto);
            Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));


            return Json(new { cliente });
        }

        public IActionResult Pedidos()
        {
            ClienteServico clienteServico = new ClienteServico(Contexto);
            PedidoServico pedidoServico = new PedidoServico(Contexto);
            ProdutosServico produtoServico = new ProdutosServico(Contexto);
            PedidoProdutoServico pedidoProdutoServico = new PedidoProdutoServico(Contexto);

            var objModel = new PedidosModel();

            IList<Pedido> pedidos = new List<Pedido>();
            Dictionary<Pedido, IList<PedidoProdutoQuantidadeModel>> pedidoProdutos = new Dictionary<Pedido, IList<PedidoProdutoQuantidadeModel>>();

            Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

            if (cliente == null)
            {
                return RedirectToAction("Index", "/Login");
            }

            if (cliente.TipoCliente == Constantes.Constantes.TipoCliente.Administrador)
            {
                pedidos = pedidoServico.ListarTodos();
            }
            else
            {
                pedidos = pedidoServico.ListarPorCliente(cliente.CodigoCliente);
            }

            foreach (var item in pedidos)
            {
                pedidoProdutos.Add(item, pedidoProdutoServico.ListarPorPedido(item.CodigoPedido).ToList());
            }

            objModel.pedidos = pedidoProdutos;
            objModel.Cliente = cliente;
            objModel.status = Rotinas.RetornarListaEnum(typeof(Constantes.Constantes.SituacoesPedidos));
            objModel.TipoCliente = cliente.TipoCliente;

            return PartialView("~/Views/Partial/_PartialUsuario/_PartialPedidos.cshtml", objModel);
        }

        public IActionResult Alterar()
        {
            ClienteServico clienteServico = new ClienteServico(Contexto);
            Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

            ClienteModel objModel = new ClienteModel();

            objModel.cliente = cliente;

            return PartialView("~/Views/Partial/_PartialUsuario/_PartialAlterar.cshtml", objModel);
        }

        public IActionResult Indicadores(int ano)
        {
            return PartialView("~/Views/Partial/_PartialUsuario/_PartialIndicadores.cshtml");
        }

        public void AlterarCliente(Cliente cliente)
        {
            ClienteServico clienteServico = new ClienteServico(Contexto);
            Cliente temp = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

            cliente.DataCadastro = temp.DataCadastro;
            cliente.TipoCliente = temp.TipoCliente;

            clienteServico.AlterarCliente(cliente);
        }

    }
}
