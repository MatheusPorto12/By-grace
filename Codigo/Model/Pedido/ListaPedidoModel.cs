namespace ByGrace.Model.Pedido
{
    public class ListaPedidoModel
    {
        public Constantes.Constantes.TipoCliente TipoCliente { get; set; }
        public IList<PedidosModel> ListaPedidos {  get; set; }
    }
}
