using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByGrace.Classes
{

    [Table("Cliente_Pedidos")]
    public class ClientePedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        [Required(ErrorMessage = "Código do pedido não informado")]
        [Display(Name = "Código pedido")]
        public int CodigoPedido { get; set; }

        [ForeignKey("Cliente"), Column(Order = 1)]
        [Required(ErrorMessage = "Informe o código do cliente"), Display(Name = "Cliente")]
        public int CodigoClientePedido { get; set; }

        [ForeignKey("Produto"), Column(Order = 2)]
        [Required(ErrorMessage = "Informe o código do produto"), Display(Name = "Produto")]
        public int CodigoProdutoPedido { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Informe o tamanho")]
        [Display(Name = "Tamanho")]
        public Constantes.Constantes.Tamanhos TamanhoProdutoPedido { get; set; }

        [Column(Order = 4)]
        [Required(ErrorMessage = "Valor do pedido não informado")]
        [Display(Name = "Valor pedido")]
        public double ValorPedido { get; set; }

        [Column(Order = 6)]
        [Required(ErrorMessage = "Forma de pagamento não informada")]
        [Display(Name = "Forma de pagamento pedido")]
        public Constantes.Constantes.FormasPagamento FormaPagamentoPedido { get; set; }

        [Column(Order = 7)]
        [Display(Name = "Situação pedido")]
        public Constantes.Constantes.SituacoesPedidos SituacaoPedido { get; set; }

    }
}
