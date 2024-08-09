using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ByGrace.Constantes;

namespace ByGrace.Classes
{
    public class Cliente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        [Required(ErrorMessage = "Código do cliente não informado")]
        [Display(Name = "Código cliente")]
        public int CodigoCliente { get; set; }

        [Column(Order = 1, TypeName = "VARCHAR")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Required(ErrorMessage = "Email não informado")]
        [Display(Name = "Email")]
        public string EmailCliente { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR")]
        [DataType(DataType.Text)]
        [StringLength(14)]
        [Required(ErrorMessage = "CPF não informado")]
        [Display(Name = "CPF")]
        public string CpfCliente { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR")]
        [DataType(DataType.Text)]
        [StringLength(14)]
        [Required(ErrorMessage = "Telefone não informado")]
        [Display(Name = "Telefone")]
        public string TelefoneCliente { get; set; }

        [Column(Order = 4, TypeName = "DATETIME")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Nascimento não informado")]
        [Display(Name = "Nascimento")]
        public DateTime NascimentoCliente { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Required(ErrorMessage = "Nome não informado")]
        [Display(Name = "Nome")]
        public string NomeCliente { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Required(ErrorMessage = "Senha não informado")]
        [Display(Name = "Senha")]
        public string SenhaCliente {  get; set; }

        [Column(Order = 7, TypeName = "int")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "")]
        [Display(Name = "Tipo")]
        public Constantes.Constantes.TipoCliente TipoCliente { get; set; }

        [Column(Order = 8)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data cadastro")]
        public DateTime DataCadastro { get; set; }
    
    }
}
