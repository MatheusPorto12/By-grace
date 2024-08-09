using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByGrace.Classes
{

    [Table("Cliente_Pedido_Produto")]
    public class PedidoProduto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Pedido")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoPedido { get; set; }

        [ForeignKey("Produtos")]
        public int CodigoProduto { get; set; }

        public int QuantidadeProduto { get; set; }

        public PedidoProduto(int codigoPedido, int CodigoProduto, int quantidadeProduto)
        {
            this.CodigoPedido = codigoPedido;
            this.CodigoProduto = CodigoProduto;
            QuantidadeProduto = quantidadeProduto;
        }
    }
}
