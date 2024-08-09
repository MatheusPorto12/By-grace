using ByGrace.Classes;

namespace ByGrace.Servicos.Implementacao
{
    public class CarrinhoServico
    {
        public Carrinho listar(List<Produtos> produtos) {
            Carrinho cart = new Carrinho();
            cart.produtos = produtos;
            return cart;
        }
    }
}
