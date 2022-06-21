using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TesteVendas.Models
{
    public class Produto
    {
        [Key, HiddenInput]
        public int ProdutoId { get; set; }
        [Required, Display(Name = "Descrição")]
        public string DscProduto { get; set; }
        [Required, Display(Name = "Valor Unitário")]
        public float VlrUnitario { get; set; }
    }
}
