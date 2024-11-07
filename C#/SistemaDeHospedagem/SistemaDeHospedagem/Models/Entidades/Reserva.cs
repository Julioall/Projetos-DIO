using SistemaDeHospedagem.Models.Enumeradores;
using System;
using System.Collections.Generic;

namespace SistemaDeHospedagem.Models.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public List<Cliente> Clientes { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public StatusReserva Status { get; set; }
        public decimal ValorTotal { get; set; }

        public Reserva()
        {
            Clientes = new List<Cliente>();
        }

        public decimal CalcularValorTotal()
        {
            TimeSpan periodoHospedagem = DataSaida.Date - DataEntrada.Date;
            int dias = periodoHospedagem.Days;
            decimal valorDiaria = Quarto.PrecoPorNoite;
            decimal valorTotal = dias * valorDiaria;

            if (dias > 10)
            {
                valorTotal *= 0.9m;
            }
            return valorTotal;
        }
    }
}
