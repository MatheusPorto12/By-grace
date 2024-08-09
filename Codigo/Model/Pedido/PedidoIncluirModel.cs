using ByGrace.Classes;

namespace ByGrace.Model.Pedido.Pedido
{
    public class PedidoIncluirModel
    {
        public IList<Produtos> ProdutosLista { get; set; }
        public double ValorTotalPedido {  get; set; }
        public Constantes.Constantes.FormasPagamento FormaPagamento { get; set;}

        public string BrCodePedido { get; set; }

    }
}
