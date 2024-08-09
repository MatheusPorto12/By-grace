using ByGrace.Classes;

namespace ByGrace.Servicos.Interfaces
{
    public interface IClientePedidoServico
    {

        public void Incluir(ClientePedido pedido);
        public void Atualizar(ClientePedido pedido);
        public ClientePedido ListarPorCodigo(int codigoPedido);
        IList<ClientePedido> ListarTodos();
    }
}
