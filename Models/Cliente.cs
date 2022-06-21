using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteVendas.Models
{
    public class Cliente
    {
        [Key, HiddenInput]
        public int ClienteId { get; set; }
        [Required, Display(Name = "Nome")]
        public string NmCliente { get; set; }
        [Required]
        public string Cidade { get; set; }
        
    }
}
