using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace TesteVendas.Models
{
    public class Venda
    {
        [Key, HiddenInput]
        public int VendaId { get; set; }
        
        public Cliente Cliente { get; set; }
        
        public int ClienteId { get; set; }
        
        public Produto Produto { get; set; }
        
        public int ProdutoId { get; set; }
        [Required]
        public int QtdVenda { get; set; }
        [Required, Display(Name = "Valor Unitário de Venda")]
        public float VlrUnitarioVenda { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Data da Venda")]
        public DateTime DthVenda { get; set; }
        
        public float VlrTotalVenda { get; set; }

        public float CalcularValorTotal (float valor,int quant)
        {
            VlrUnitarioVenda = valor;
            QtdVenda = quant;
            VlrTotalVenda = valor * quant;
            return VlrTotalVenda;
        }
    }
}
