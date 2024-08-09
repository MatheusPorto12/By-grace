using ByGrace.Classes;

namespace ByGrace.Servicos.Interfaces
{
    public interface IClienteServico
    {
        public void incluir(Cliente cliente);
        public Cliente logar(String email, String senha);
        public Cliente listarPorEmail(String email);
    }
}
