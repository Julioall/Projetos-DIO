using SistemaDeHospedagem.Models.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeHospedagem.Models.Entidades
{
    public class Quarto
    {
        public int Id { get; set; }
        public required int Numero { get; set; }
        public TipoQuarto Tipo { get; set; }
        public required string Descricao { get; set; }
        public int Capacidade { get; set; }
        public decimal PrecoPorNoite { get; set; }
    }
}
