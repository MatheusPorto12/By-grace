using ByGrace.Classes;
using ByGrace.Data;
using Microsoft.EntityFrameworkCore;
using static ByGrace.Servicos.Interfaces.IProdutosServico;

namespace ByGrace.Servicos.Interfaces
{
    public interface IProdutosServico
    {
        public void Incluir(Produtos produto);
        public void Atualizar(Produtos produto);
        public Produtos ListarPorCodigo(int codigoProduto);
        IList<Produtos> ListarTodos();
        public void Excluir(int codigoProduto);
    }
}
