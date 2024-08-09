using ByGrace.Classes.Comum;
using ByGrace.Data;
using ByGrace.IRepositorio;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ByGrace.Repositorio
{
    public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {

        private readonly AppDbContext _context;

        public Repositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Alterar(T tipo, Func<T, object> chave)
        {
            if (tipo == null)
            {
                throw new ArgumentNullException("Entidade não instanciada!");
            }

            if (tipo is IValidacao)
            {
                ((IValidacao)tipo).Validacao();
            }

            EntityEntry entidadeExitente = _context.Entry(tipo);

            if (entidadeExitente.State == EntityState.Detached)
            {
                if (chave != null)
                {
                    var set = _context.Set<T>();
                    T attachedEntity = set.Find(chave(tipo));

                    if (attachedEntity != null)
                    {
                        var attachedEntry = _context.Entry(attachedEntity);
                        if (attachedEntry.State != EntityState.Deleted)
                        {
                            attachedEntry.CurrentValues.SetValues(tipo);
                        }
                    }
                    else
                    {
                        if (entidadeExitente.State != EntityState.Deleted)
                        {
                            entidadeExitente.State = EntityState.Modified;
                        }
                    }
                }
                else
                {
                    _context.Set<T>().Attach(tipo);
                    entidadeExitente.State = EntityState.Modified;
                }
            }
        }

        public void Excluir(T tipo, Func<T, object> chave)
        {
            if (tipo == null)
            {
                throw new ArgumentNullException("Entidade não instanciada!");
            }

            EntityEntry entidadeExitente = _context.Entry(tipo);

            //if (entidadeExitente.State == EntityState.Detached)
            //{
            var set = _context.Set<T>();
            T attachedEntity = set.Find(chave(tipo));

            if (attachedEntity != null)
            {
                _context.Set<T>().Attach(attachedEntity);
                _context.Set<T>().Remove(attachedEntity);
            }
        }

        public void Incluir(T tipo)
        {
            if (tipo == null)
            {
                throw new ArgumentNullException("Entidade não instanciada!");
            }

            if (tipo is IValidacao)
            {
                ((IValidacao)tipo).Validacao();
            }

            _context.Set<T>().Add(tipo);
        }

        public T ListarPorCodigo(object codigo)
        {
            return _context.Set<T>().Find(codigo);
        }

        public IEnumerable<T> ListarTodos()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IQueryable<T> RetornarFiltro(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Excluir(int codigo)
        {
            T entidade = _context.Set<T>().Find(codigo);

            if (entidade == null)
            {
                return;
            }

            if (_context.Entry(entidade).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entidade);
            }
            _context.Set<T>().Remove(entidade);
        }
    }
}
