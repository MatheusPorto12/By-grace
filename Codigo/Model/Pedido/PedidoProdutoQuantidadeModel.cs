using ByGrace.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ByGrace.Model.Pedido
{
    public class PedidoProdutoQuantidadeModel
    {
        public Produtos produtos {  get; set; }
        public int quantidade { get; set; }
    }
}
