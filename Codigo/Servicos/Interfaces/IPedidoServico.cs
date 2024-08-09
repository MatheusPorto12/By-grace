using ByGrace.Classes;

namespace ByGrace.Servicos.Interfaces
{
    public interface IPedidoServico
    {
        public void Incluir(Pedido pedido);
        public Pedido ListarPorCodigo(int codigoPedido);
        IList<Pedido> ListarTodos();
        public void Excluir(int codigoPedido);
    }
}
