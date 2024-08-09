using ByGrace.Classes;
using ByGrace.IRepositorio;

namespace ByGrace.Servicos.Implementacao
{
    public class IndicadorServico : ServicoBase
    {
        public IndicadorServico(IRepositorioTrabalho contexto) : base(contexto)
        {
        }

        public double[] ValorGeralVendasPorMes(int ano)
        {
            List<Pedido> ped = new List<Pedido>();
            ped = Contexto.PedidoRepositorio.RetornarFiltro(p => p.DataPedido.Year == ano).ToList();
            double[] valores = new double[12];

            for (int i = 0; i < 12; i++)
            {
                double valor = 0;
                foreach (Pedido p in ped)
                {
                    if (p.DataPedido.Month - 1 == i)
                    {
                        valor += p.ValorPedido;
                    }
                }
                valores[i] = valor;
            }
            return valores;
        }
    
        public int[] CrescimentoCadastroClientePorMes(int ano)
        {
            List<Cliente> cli = new List<Cliente>();
            cli = Contexto.ClienteRepositorio.RetornarFiltro(c => c.DataCadastro.Year == ano).ToList();
            int[] valores = new int[12];

            for (int i = 0; i < 12; i++)
            {
                int valor = 0;
                foreach (Cliente c in cli)
                {
                    if (c.DataCadastro.Month - 1 == i)
                    {
                        valor++;
                    }
                }
                valores[i] = valor;
            }
            return valores;
        }

        public int[] QuantidadeDeVendasPorMes(int ano)
        {
            List<Pedido> ped = new List<Pedido>();
            ped = Contexto.PedidoRepositorio.RetornarFiltro(p => p.DataPedido.Year == ano && p.SituacaoPedido == Constantes.Constantes.SituacoesPedidos.Pago).ToList();
            int[] valores = new int[12];

            for (int i = 0; i < 12; i++)
            {
                int valor = 0;
                foreach (Pedido p in ped)
                {
                    if (p.DataPedido.Month - 1 == i)
                    {
                        valor++;
                    }
                }
                valores[i] = valor;
            }
            return valores;
        }
    }
}
