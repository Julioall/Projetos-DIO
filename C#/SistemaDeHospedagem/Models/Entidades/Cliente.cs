using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeHospedagem.Models.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public string? Email { get; set; }
        public required string Telefone { get; set; }
    }
}
