using ByGrace.Classes;
using ByGrace.Classes.Comum;
using ByGrace.Data;
using ByGrace.IRepositorio;
using ByGrace.Servicos.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ByGrace.Servicos
{
    public class ClienteServico : ServicoBase, IClienteServico
    {

        public ClienteServico(IRepositorioTrabalho contexto) : base(contexto)
        {
        }

        public void incluir(Cliente cliente)
        {
            Cliente clienteDuplicado = Contexto.ClienteRepositorio.RetornarFiltro(
                c => c.CpfCliente == cliente.CpfCliente ||
                c.EmailCliente == cliente.EmailCliente).FirstOrDefault();

            Contexto.ClienteRepositorio.Incluir(cliente);
            Salvar();
        }

        public Cliente logar(string email, string senha)
        {
            Cliente cliente = Contexto.ClienteRepositorio.RetornarFiltro(c => c.EmailCliente == email && c.SenhaCliente == senha).FirstOrDefault();
            if (cliente == null) { return new Cliente(); }

            return cliente;
        }

        public Cliente listarPorEmail(string email) {

            Cliente cliente = Contexto.ClienteRepositorio.RetornarFiltro(c => c.EmailCliente == email).FirstOrDefault();

            return cliente;

        }
        public Cliente ListarPorCodigo(int codigoCliente)
        {

            Cliente cliente = Contexto.ClienteRepositorio.RetornarFiltro(c => c.CodigoCliente == codigoCliente).FirstOrDefault();

            return cliente;

        }
        public void AlterarCliente(Cliente cliente)
        {
            Contexto.ClienteRepositorio.Alterar(cliente, c => c.CodigoCliente);
            Salvar();
        }
    }
}
