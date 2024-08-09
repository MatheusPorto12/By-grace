using System.Linq.Expressions;

namespace ByGrace.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        void Incluir(T tipo);
        void Alterar(T tipo, Func<T, object> chave);
        void Excluir(T tipo, Func<T, object> chave);
        void Excluir(int codigo);
        IEnumerable<T> ListarTodos();
        T ListarPorCodigo(object codigo);
        IQueryable<T> RetornarFiltro(Expression<Func<T, bool>> predicate);
    }
}
