using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ByGrace.Classes
{
    public class Pedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        [Required(ErrorMessage = "Informe o código do produto")]
        [Display(Name = "Código pedido")]
        public int CodigoPedido { get; set; }

        [ForeignKey("Cliente")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoClientePedido { get; set; }

        [Column(Order = 1)]
        [Required(ErrorMessage = "Informe o código do produto")]
        [Display(Name = "Código pedido")]
        public double ValorPedido { get; set; }

        [Column(Order = 2)]
        [Required(ErrorMessage = "Informe o código do produto")]
        [Display(Name = "Código pedido")]
        public Constantes.Constantes.FormasPagamento FormaPagamentoPedido { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Informe o código do produto")]
        [Display(Name = "Código pedido")]
        public Constantes.Constantes.SituacoesPedidos SituacaoPedido { get; set; }

        [Column(Order = 4)]
        [Required(ErrorMessage = "Informe o código do produto")]
        [Display(Name = "Data pedido")]
        public DateTime DataPedido { get; set; }

        [Column(Order = 5)]
        [Required(ErrorMessage = "Informe o código do produto")]
        [Display(Name = "BrCode")]
        public string BrCodePedido { get; set; }
    }
}
