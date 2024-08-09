using ByGrace.Classes;
using ByGrace.IRepositorio;
using ByGrace.Model.Cliente;
using ByGrace.Servicos.Interfaces;

namespace ByGrace.Servicos.Implementacao
{
    public class ClientePedidoServico : ServicoBase, IClientePedidoServico
    {

        public ClientePedidoServico(IRepositorioTrabalho contexto) : base(contexto)
        {

        }

        public void Atualizar(ClientePedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Incluir(ClientePedido pedido)
        {
            Contexto.ClientePedidoRepositorio.Incluir(pedido);
            Salvar();
        }

        public ClientePedido ListarPorCodigo(int codigoPedido)
        {
            throw new NotImplementedException();
        }

        public IList<ClientePedido> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public IList<ClientePedido> ListarTodos(int codigoCliente)
        {
            throw new NotImplementedException();
        }
    }
}
