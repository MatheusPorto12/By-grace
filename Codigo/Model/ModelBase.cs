using ByGrace.Classes;
using ByGrace.IRepositorio;

namespace ByGrace.Model
{
    public class ModelBase
    {

        private Classes.Cliente clienteLogado;

        public ModelBase(Classes.Cliente cliente)
        {
            clienteLogado = cliente;
        }

        public Classes.Cliente UsuarioLogado
        {
            get
            {
                return clienteLogado;
            }
        }

    }
}
