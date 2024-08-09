using ByGrace.Classes;
using ByGrace.Model.Pedido;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ByGrace.Model
{
    public class PedidosModel
    {
        public ByGrace.Classes.Cliente Cliente { get; set; }
        public Dictionary<Classes.Pedido, IList<PedidoProdutoQuantidadeModel>> pedidos { get; set; }

        public SelectList status { get; set; }

        public Constantes.Constantes.TipoCliente TipoCliente { get; set; }
    }
}