using ByGrace.Constantes;
using ByGrace.Classes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ByGrace.Model
{
    public class ProdutosModel 
    {

        //public ProdutosModel(Cliente clienteLogado) : base(clienteLogado) { }

        public Produtos Produto { get; set; }
        public Constantes.Constantes.TipoCliente TipoCliente { get; set; }

        //Listas
        public SelectList Tamanhos { get; set; }
        public SelectList Categoria { get; set; }
        public IList<Produtos> ProdutosLista { get; set; }

    }
}
