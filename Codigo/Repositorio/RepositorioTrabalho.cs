using ByGrace.Classes;
using ByGrace.Data;
using ByGrace.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace ByGrace.Repositorio
{
    public class RepositorioTrabalho : IRepositorioTrabalho
    {

        private AppDbContext _context;

        private IRepositorio<Produtos> _produtoRepositorio;
        private IRepositorio<Cliente> _clienteRepositorio;
        private IRepositorio<Pedido> _pedidoRepositorio;
        private IRepositorio<PedidoProduto> _pedidoProdutoRepositorio;
        private IRepositorio<ClientePedido> _clientePedidoRepositorio;

        public RepositorioTrabalho(DbContextOptions<AppDbContext> context)
        {
            _context = new AppDbContext(context);
        }

        public void SalvarAlteracoes()
        {
            _context.SaveChanges();
        }

        public void Descartar()
        {
            _context.Dispose();
        }

        public IRepositorio<Produtos> ProdutoRepositorio
        {
            get { return _produtoRepositorio ?? (_produtoRepositorio = new Repositorio<Produtos>(_context)); }
        }

        public IRepositorio<Cliente> ClienteRepositorio
        {
            get { return _clienteRepositorio ?? (_clienteRepositorio = new Repositorio<Cliente>(_context)); }
        }

        public IRepositorio<Pedido> PedidoRepositorio 
        {
            get { return _pedidoRepositorio ?? (_pedidoRepositorio = new Repositorio<Pedido>(_context)); }
        }

        public IRepositorio<PedidoProduto> PedidoProdutoRepositorio
        {
            get { return _pedidoProdutoRepositorio ?? (_pedidoProdutoRepositorio = new Repositorio<PedidoProduto>(_context)); }
        }

        public IRepositorio<ClientePedido> ClientePedidoRepositorio
        {
            get { return _clientePedidoRepositorio ?? (_clientePedidoRepositorio = new Repositorio<ClientePedido>(_context)); }
        }

    }
}
