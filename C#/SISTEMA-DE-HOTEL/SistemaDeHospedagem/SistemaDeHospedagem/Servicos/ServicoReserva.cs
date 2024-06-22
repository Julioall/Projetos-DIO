using SistemaDeHospedagem.Models.Entidades;
using SistemaDeHospedagem.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeHospedagem.Servicos
{
    public class ServicoReserva
    {
        private readonly RepositorioReserva _repositorioReserva;
        private readonly RepositorioQuarto _repositorioQuarto;
        private readonly RepositorioCliente _repositorioCliente;

        public ServicoReserva(RepositorioReserva repositorioReserva, RepositorioQuarto repositorioQuarto, RepositorioCliente repositorioCliente)
        {
            _repositorioReserva = repositorioReserva ?? throw new ArgumentNullException(nameof(repositorioReserva));
            _repositorioQuarto = repositorioQuarto ?? throw new ArgumentNullException(nameof(repositorioQuarto));
            _repositorioCliente = repositorioCliente ?? throw new ArgumentException(nameof(repositorioCliente));
        }

        public void ListarReservas()
        {
            Console.Clear();
            Console.WriteLine("### Listagem de Reservas ###");

            var reservas = _repositorioReserva.ObterTodos();

            if (reservas == null || !reservas.Any())
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
            }
            else
            {
                foreach (var reserva in reservas)
                {
                    Console.WriteLine($"ID: {reserva.Id} | Quarto: {reserva.Quarto.Numero} | Hóspede(s): {string.Join(", ", reserva.Clientes.Select(c => c.Nome))} | Data de Entrada: {reserva.DataEntrada.ToShortDateString()} | Data de Saída: {reserva.DataSaida.ToShortDateString()} | Valor Total: R${reserva.ValorTotal}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void AdicionarReserva()
        {
            Console.Clear();
            Console.WriteLine("### Adicionar Nova Reserva ###");

            Console.Write("ID do Quarto: ");
            int idQuarto;
            while (!int.TryParse(Console.ReadLine(), out idQuarto))
            {
                Console.WriteLine("ID inválido. Digite novamente: ");
            }

            Quarto quarto = _repositorioQuarto.ObterPorId(idQuarto);
            if (quarto == null)
            {
                Console.WriteLine("Quarto não encontrado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Quantos hóspedes deseja associar a esta reserva? ");
            int numHospedes;
            while (!int.TryParse(Console.ReadLine(), out numHospedes) || numHospedes < 1)
            {
                Console.WriteLine("Número inválido. Digite novamente: ");
            }

            if (numHospedes > quarto.Capacidade)
            {
                Console.WriteLine($"O quarto selecionado tem capacidade para {quarto.Capacidade} hóspede(s). Não é possível acomodar {numHospedes} hóspede(s).");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            List<Cliente> clientes = new List<Cliente>();
            for (int i = 0; i < numHospedes; i++)
            {
                Console.Write($"ID do Hóspede {i + 1}: ");
                int idCliente;
                while (!int.TryParse(Console.ReadLine(), out idCliente))
                {
                    Console.WriteLine("ID inválido. Digite novamente: ");
                }

                Cliente cliente = _repositorioCliente.ObterPorId(idCliente);
                if (cliente == null)
                {
                    Console.WriteLine($"Hóspede com ID {idCliente} não encontrado.");
                }
                else
                {
                    clientes.Add(cliente);
                }
            }

            Console.Write("Data de Entrada (dd/mm/aaaa): ");
            DateTime dataEntrada;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEntrada))
            {
                Console.WriteLine("Formato de data inválido. Digite novamente (dd/mm/aaaa): ");
            }

            Console.Write("Data de Saída (dd/mm/aaaa): ");
            DateTime dataSaida;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataSaida))
            {
                Console.WriteLine("Formato de data inválido. Digite novamente (dd/mm/aaaa): ");
            }

            Reserva novaReserva = new Reserva
            {
                Quarto = quarto,
                Clientes = clientes,
                DataEntrada = dataEntrada,
                DataSaida = dataSaida
            };

            novaReserva.ValorTotal = novaReserva.CalcularValorTotal();

            _repositorioReserva.Adicionar(novaReserva);
            Console.WriteLine("Reserva adicionada com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void AtualizarReserva()
        {
            Console.Clear();
            Console.WriteLine("### Atualizar Reserva ###");
            Console.Write("Digite o ID da Reserva que deseja atualizar: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente: ");
            }

            Reserva reserva = _repositorioReserva.ObterPorId(id);
            if (reserva == null)
            {
                Console.WriteLine("Reserva não encontrada.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Reserva encontrada: Quarto {reserva.Quarto.Numero}");
            Console.WriteLine("Digite as novas datas:");

            Console.Write("Data de Entrada (dd/mm/aaaa): ");
            DateTime dataEntrada;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEntrada))
            {
                Console.WriteLine("Formato de data inválido. Digite novamente (dd/mm/aaaa): ");
            }

            Console.Write("Data de Saída (dd/mm/aaaa): ");
            DateTime dataSaida;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataSaida))
            {
                Console.WriteLine("Formato de data inválido. Digite novamente (dd/mm/aaaa): ");
            }

            reserva.DataEntrada = dataEntrada;
            reserva.DataSaida = dataSaida;

            reserva.ValorTotal = reserva.CalcularValorTotal();

            _repositorioReserva.Atualizar(reserva);
            Console.WriteLine("Reserva atualizada com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ExcluirReserva()
        {
            Console.Clear();
            Console.WriteLine("### Excluir Reserva ###");
            Console.Write("Digite o ID da Reserva que deseja excluir: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente: ");
            }

            Reserva reserva = _repositorioReserva.ObterPorId(id);
            if (reserva == null)
            {
                Console.WriteLine("Reserva não encontrada.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Reserva encontrada: Quarto {reserva.Quarto.Numero}");
            Console.Write("Tem certeza que deseja excluir esta reserva? (S/N): ");
            string confirmacao = Console.ReadLine();
            if (confirmacao.ToUpper() == "S")
            {
                _repositorioReserva.Excluir(id);
                Console.WriteLine("Reserva excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
