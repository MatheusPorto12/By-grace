using ByGrace.Classes;
using ByGrace.Data;
using ByGrace.IRepositorio;
using ByGrace.Servicos.Interfaces;

namespace ByGrace.Servicos
{
    public class ProdutosServico : ServicoBase, IProdutosServico
    {
        public ProdutosServico(IRepositorioTrabalho contexto) : base(contexto)
        {

        }

        public void Atualizar(Produtos produto)
        {
            Contexto.ProdutoRepositorio.Alterar(produto, p => p.CodigoProduto);
            Salvar();
        }

        public void Incluir(Produtos produto)
        {
            Contexto.ProdutoRepositorio.Incluir(produto);
            Salvar();
        }

        public Produtos ListarPorCodigo(int codigoProduto)
        {
            return Contexto.ProdutoRepositorio.ListarPorCodigo(codigoProduto);
        }

        public IList<Produtos> ListarTodos()
        {
            return Contexto.ProdutoRepositorio.ListarTodos().ToList();
        }

        public IList<Produtos> ListarTodos(int categoria)
        {
            switch (categoria)
            {

                case -1:
                    return Contexto.ProdutoRepositorio.ListarTodos().ToList();

                default:
                    return Contexto.ProdutoRepositorio.RetornarFiltro(c => c.CategoriaProduto == (Constantes.Constantes.CategoriaProduto)categoria).ToList();
            } 
        }

        public IList<Produtos> ListarDisponiveis(int categoria)
        {

            switch (categoria)
            {

                case -1:
                    return Contexto.ProdutoRepositorio.RetornarFiltro(p => p.DisponivelProduto == true).ToList();
                    
                default:
                    return Contexto.ProdutoRepositorio.RetornarFiltro(p => p.DisponivelProduto == true && p.CategoriaProduto == (Constantes.Constantes.CategoriaProduto)categoria).ToList();
            }     
        }

        public void Excluir(int codigoProduto)
        {
            Contexto.ProdutoRepositorio.Excluir(codigoProduto);
            Salvar();
        }
    }
}
