using ByGrace.Classes;

namespace ByGrace.Model.Cliente
{
    public class ClientePedidoModel
    {
        public int CodigoClientePedido { get; set; }
        public double ValorPedido { get; set; }
        public Constantes.Constantes.FormasPagamento FormaPagamentoPedido { get; set; }
        public Constantes.Constantes.SituacoesPedidos SituacaoPedido { get; set; }
        public IList<Produtos> ProdutosPedido { get; set; }

    }
}
