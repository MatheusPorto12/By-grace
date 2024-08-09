using ByGrace.Classes;
using ByGrace.IRepositorio;
using ByGrace.Servicos.Interfaces;

namespace ByGrace.Servicos.Implementacao
{
    public class PedidoServico : ServicoBase, IPedidoServico
    {
        public PedidoServico(IRepositorioTrabalho contexto) : base(contexto)
        {
        }

        public void Excluir(int codigoPedido)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Pedido pedido)
        {
            Contexto.PedidoRepositorio.Incluir(pedido);
            Salvar();
        }

        public int IncluirPedidoProduto(Pedido pedido)
        {
            Contexto.PedidoRepositorio.Incluir(pedido);
            Salvar();

            return pedido.CodigoPedido;
        }

        public Pedido ListarPorCodigo(int codigoPedido)
        {
            return Contexto.PedidoRepositorio.ListarPorCodigo(codigoPedido);
        }
        public void Atualizar(Pedido pedido)
        {
            Pedido p = Contexto.PedidoRepositorio.ListarPorCodigo(pedido.CodigoPedido);
            pedido.DataPedido = p.DataPedido;
            pedido.BrCodePedido = p.BrCodePedido;

            Contexto.PedidoRepositorio.Alterar(pedido, p => p.CodigoPedido);
            Salvar();
        }
        public IList<Pedido> ListarPorCliente(int codigoCliente)
        {
            List<Pedido> ped = Contexto.PedidoRepositorio.RetornarFiltro(p => p.CodigoClientePedido == codigoCliente).ToList();
            return ped;
        }

        public IList<Pedido> ListarTodos()
        {
            List<Pedido> ped = new List<Pedido> ();
            ped = Contexto.PedidoRepositorio.ListarTodos().ToList();

            return ped;
        }
    }
}
