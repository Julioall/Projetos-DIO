using SistemaDeHospedagem.Models.Entidades;

namespace SistemaDeHospedagem.Repositorios
{
    public class RepositorioReserva : IRepositorio<Reserva>
    {
        private readonly List<Reserva> _reservas = new List<Reserva>();

        public void Adicionar(Reserva reserva)
        {
            reserva.Id = _reservas.Count + 1; 
            _reservas.Add(reserva);
        }

        public void Atualizar(Reserva reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva));
            }

            var reservaExistente = ObterPorId(reserva.Id);
            if (reservaExistente != null)
            {
                reservaExistente.Clientes = reserva.Clientes;
                reservaExistente.Quarto = reserva.Quarto;
                reservaExistente.DataEntrada = reserva.DataEntrada;
                reservaExistente.DataSaida = reserva.DataSaida;
                reservaExistente.Status = reserva.Status;
                reservaExistente.ValorTotal = reserva.ValorTotal;
            }
        }

        public void Excluir(int id)
        {
            var reserva = ObterPorId(id);
            if (reserva != null)
            {
                _reservas.Remove(reserva);
            }
        }

        public Reserva ObterPorId(int id)
        {
            return _reservas.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Reserva> ObterTodos()
        {
            return _reservas.ToList(); 
        }
    }
}
