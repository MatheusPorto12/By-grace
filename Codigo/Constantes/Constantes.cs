using System.ComponentModel;

namespace ByGrace.Constantes
{
    public class Constantes
    {

        public enum Tamanhos
        {
            [Description("P")]
            P = 1,
            [Description("M")]
            M = 2,
            [Description("G")]
            G = 3,
            [Description("GG")]
            GG = 4,
            [Description("XG")]
            XG = 5
        }

        public enum TipoCliente
        {
            [Description("Adminsitrador")]
            Administrador = 0,
            [Description("Cliente")]
            Cliente = 1,
        }

        public enum FormasPagamento
        {
            [Description("Cartão")]
            Cartao = 0,
            [Description("Pix")]
            Pix = 1,
            [Description("Dinheiro")]
            Dinheiro = 2,
        }

        public enum SituacoesPedidos
        {
            [Description("Realizado")]
            Realizado = 0,
            [Description("Pago")]
            Pago = 1,
            [Description("Finalizado")]
            Finalizado = 2,
            [Description("Separado")]
            Separado = 3,
            [Description("Pronto")]
            Pronto = 4,
            [Description("Cancelado")]
            Cancelado = 5
        }

        public enum CategoriaProduto
        {
            [Description("Blusas")]
            Blusas = 0,
            [Description("Vestidos")]
            Vestidos = 1,
            [Description("Saias")]
            Saias = 2,
            [Description("Jeans")]
            Jeans = 3,
        }
    }
}
