using ByGrace.Classes;
using ByGrace.IRepositorio;
using ByGrace.Model.Pedido;

namespace ByGrace.Servicos.Implementacao
{
    public class PedidoProdutoServico : ServicoBase
    {
        public PedidoProdutoServico(IRepositorioTrabalho contexto) : base(contexto)
        {

        }

        public void Incluir(List<PedidoProduto> pedidoProduto)
        {
            foreach(var prod in pedidoProduto)
            {
                Contexto.PedidoProdutoRepositorio.Incluir(prod);
            }
            
            Salvar();
        }
        public IList<PedidoProdutoQuantidadeModel> ListarPorPedido(int codigoPedido)
        {
            IList<PedidoProduto> pedidoProduto = Contexto.PedidoProdutoRepositorio.ListarTodos().ToList().Where(e => e.CodigoPedido == codigoPedido).ToList();
            List<PedidoProdutoQuantidadeModel> pedidoProdutoQuantidades = new List<PedidoProdutoQuantidadeModel>();

            foreach (PedidoProduto p in pedidoProduto)
            {
                PedidoProdutoQuantidadeModel objModel = new PedidoProdutoQuantidadeModel();
                objModel.produtos = Contexto.ProdutoRepositorio.ListarPorCodigo(p.CodigoProduto);
                objModel.quantidade = p.QuantidadeProduto;
                pedidoProdutoQuantidades.Add(objModel);
            }

            return pedidoProdutoQuantidades;
        }
    }
}
