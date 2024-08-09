using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ByGrace.Classes
{
    public class Produtos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        [Required(ErrorMessage = "Informe o código do produto")]
        [Display(Name = "Código produto")]
        public int CodigoProduto { get; set; }

        [Column(Order = 1, TypeName = "varchar")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Nome produto")]
        public string NomeProduto { get; set; }

        [Column(Order = 2, TypeName = "varchar")]
        [DataType(DataType.Text)]
        [StringLength(4000)]
        [Display(Name = "Descrição produto")]
        public string DescricaoProduto { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Informe o tamanho")]
        [Display(Name = "Tamanho")]
        public Constantes.Constantes.Tamanhos TamanhoProduto { get; set; }

        [Column(Order = 4)]
        [Required(ErrorMessage = "Informe o valor do produto")]
        [Display(Name = "Valor")]
        public double ValorProduto { get; set; }

        [Column(Order = 5)]
        [Required(ErrorMessage = "Informe a quantidade do produto")]
        [Display(Name = "Quantidade")]
        public int QuantidadeProduto { get; set; }

        [Column(Order = 6)]
        [Required(ErrorMessage = "Informe se o produto está disponível")]
        [Display(Name = "Disponível")]
        public bool DisponivelProduto { get; set; }

        [Column(Order = 7)]
        [Required(ErrorMessage = "Informe se o produto está disponível")]
        [Display(Name = "Categoria")]
        public Constantes.Constantes.CategoriaProduto CategoriaProduto { get; set; }

        [Column(Order = 8)]
        [Required(ErrorMessage = "Informe se o produto está disponível")]
        [Display(Name = "Date de cadastro")]
        public DateTime DataCadastroProduto { get; set; }

        [Column(Order = 9, TypeName = "varbinary(max)")]
        [Required(ErrorMessage = "Informe uma foto do produto")]
        [Display(Name = "Foto")]
        public byte[] FotoProduto { get; set; }

    }
}
