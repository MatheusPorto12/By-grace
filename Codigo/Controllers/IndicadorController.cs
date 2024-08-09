using ByGrace.IRepositorio;
using ByGrace.Servicos;
using ByGrace.Servicos.Implementacao;

namespace ByGrace.Controllers
{
    public class IndicadorController : ControllerBase
    {
        public IndicadorController(IRepositorioTrabalho indicadorRepositorio) : base(indicadorRepositorio)
        {

        }

        public double[] ValorGeralVendasPorAno(int anoReferencia)
        {
            IndicadorServico indicadorServico = new IndicadorServico(Contexto);

            return indicadorServico.ValorGeralVendasPorMes(anoReferencia);
        }

        public int[] CrescimentoCadatroClientePorAno(int anoReferencia)
        {
            IndicadorServico indicadorServico = new IndicadorServico(Contexto);

            return indicadorServico.CrescimentoCadastroClientePorMes(anoReferencia);
        }

        public int[] QuantidadeDeVendasPorAno(int anoReferencia)
        {
            IndicadorServico indicadorServico = new IndicadorServico(Contexto);

            return indicadorServico.QuantidadeDeVendasPorMes(anoReferencia);
        }
    }
}
