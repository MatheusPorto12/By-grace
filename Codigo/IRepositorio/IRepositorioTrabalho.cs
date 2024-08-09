using ByGrace.Classes;

namespace ByGrace.IRepositorio
{
    public interface IRepositorioTrabalho
    {
        void SalvarAlteracoes();
        IRepositorio<Produtos> ProdutoRepositorio { get; }
        IRepositorio<Cliente> ClienteRepositorio { get; }
        IRepositorio<Pedido> PedidoRepositorio { get; }
        IRepositorio<PedidoProduto> PedidoProdutoRepositorio { get; }
        IRepositorio<ClientePedido> ClientePedidoRepositorio { get; }
    }
}
