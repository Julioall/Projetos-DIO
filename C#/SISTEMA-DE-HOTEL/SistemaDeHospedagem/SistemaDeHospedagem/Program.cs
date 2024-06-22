using SistemaDeHospedagem.Models.Entidades;
using SistemaDeHospedagem.Models.Enumeradores;
using SistemaDeHospedagem.Repositorios;
using SistemaDeHospedagem.Servicos;

namespace SistemaDeHospedagem.ConsoleApp
{
    class Program
    {
        private static ServicoCliente _servicoCliente;
        private static ServicoQuarto _servicoQuarto;
        private static ServicoReserva _servicoReserva;

        static void Main()
        {
            RepositorioCliente repositorioCliente = new RepositorioCliente();
            RepositorioQuarto repositorioQuarto = new RepositorioQuarto();
            RepositorioReserva repositorioReserva = new RepositorioReserva();

            _servicoCliente = new ServicoCliente(repositorioCliente);
            _servicoQuarto = new ServicoQuarto(repositorioQuarto);
            _servicoReserva = new ServicoReserva(repositorioReserva, repositorioQuarto, repositorioCliente);

            MostrarMenu();
        }

        static void MostrarMenu()
        {
            bool sair = false;

            do
            {
                Console.Clear();
                Console.WriteLine("### Sistema de Hospedagem - Menu Principal ###");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Gerenciar Hóspedes");
                Console.WriteLine("2. Gerenciar Quartos");
                Console.WriteLine("3. Gerenciar Reservas");
                Console.WriteLine("0. Sair do Programa");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuClientes();
                        break;
                    case "2":
                        MenuQuartos();
                        break;
                    case "3":
                        MenuReservas();
                        break;
                    case "0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (!sair);
        }

        static void MenuClientes()
        {
            bool voltar = false;

            do
            {
                Console.Clear();
                Console.WriteLine("### Gerenciar Hóspedes ###");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Listar Hóspedes");
                Console.WriteLine("2. Adicionar Hóspede");
                Console.WriteLine("3. Atualizar Hóspede");
                Console.WriteLine("4. Excluir Hóspede");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _servicoCliente.ListarClientes();
                        break;
                    case "2":
                        _servicoCliente.AdicionarCliente();
                        break;
                    case "3":
                        _servicoCliente.AtualizarCliente();
                        break;
                    case "4":
                        _servicoCliente.ExcluirCliente();
                        break;
                    case "0":
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (!voltar);
        }

        static void MenuQuartos()
        {
            bool voltar = false;

            do
            {
                Console.Clear();
                Console.WriteLine("### Gerenciar Quartos ###");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Listar Quartos");
                Console.WriteLine("2. Adicionar Quarto");
                Console.WriteLine("3. Atualizar Quarto");
                Console.WriteLine("4. Excluir Quarto");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _servicoQuarto.ListarQuartos();
                        break;
                    case "2":
                        _servicoQuarto.AdicionarQuarto();
                        break;
                    case "3":
                        _servicoQuarto.AtualizarQuarto();
                        break;
                    case "4":
                        _servicoQuarto.ExcluirQuarto();
                        break;
                    case "0":
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (!voltar);
        }

        static void MenuReservas()
        {
            bool sair = false;
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("### Menu de Reservas ###");
                Console.WriteLine("1. Listar Reservas");
                Console.WriteLine("2. Adicionar Reserva");
                Console.WriteLine("3. Atualizar Reserva");
                Console.WriteLine("4. Excluir Reserva");
                Console.WriteLine("5. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        _servicoReserva.ListarReservas();
                        break;
                    case "2":
                        _servicoReserva.AdicionarReserva();
                        break;
                    case "3":
                        _servicoReserva.AtualizarReserva();
                        break;
                    case "4":
                        _servicoReserva.ExcluirReserva();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
