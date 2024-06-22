using SistemaDeHospedagem.Models.Entidades;
using SistemaDeHospedagem.Repositorios;
using System;

namespace SistemaDeHospedagem.Servicos
{
    public class ServicoCliente
    {
        private readonly RepositorioCliente _repositorioCliente;

        public ServicoCliente(RepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente ?? throw new ArgumentNullException(nameof(repositorioCliente));
        }

        public void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("### Listagem de Hóspedes ###");
            var clientes = _repositorioCliente.ObterTodos();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | CPF: {cliente.CPF}");
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void AdicionarCliente()
        {
            Console.Clear();
            Console.WriteLine("### Adicionar Novo Hóspede ###");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Cliente novoCliente = new Cliente
            {
                Nome = nome,
                CPF = cpf,
                Email = email,
                Telefone = telefone,
            };

            _repositorioCliente.Adicionar(novoCliente);
            Console.WriteLine("Hóspede adicionado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void AtualizarCliente()
        {
            Console.Clear();
            Console.WriteLine("### Atualizar Hóspede ###");
            Console.Write("Digite o ID do Hóspede que deseja atualizar: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente: ");
            }

            Cliente cliente = _repositorioCliente.ObterPorId(id);
            if (cliente == null)
            {
                Console.WriteLine("Hóspede não encontrado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Hóspede encontrado: {cliente.Nome}");
            Console.WriteLine("Digite os novos dados:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            Console.Write("Data de Nascimento (dd/mm/aaaa): ");
            DateTime dataNascimento;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
            {
                Console.WriteLine("Formato de data inválido. Digite novamente (dd/mm/aaaa): ");
            }

            cliente.Nome = nome;
            cliente.CPF = cpf;
            cliente.Email = email;
            cliente.Telefone = telefone;

            _repositorioCliente.Atualizar(cliente);
            Console.WriteLine("Hóspede atualizado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("### Excluir Hóspede ###");
            Console.Write("Digite o ID do Hóspede que deseja excluir: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente: ");
            }

            Cliente cliente = _repositorioCliente.ObterPorId(id);
            if (cliente == null)
            {
                Console.WriteLine("Hóspede não encontrado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Hóspede encontrado: {cliente.Nome}");
            Console.Write("Tem certeza que deseja excluir este hóspede? (S/N): ");
            string confirmacao = Console.ReadLine();
            if (confirmacao.ToUpper() == "S")
            {
                _repositorioCliente.Excluir(id);
                Console.WriteLine("Hóspede excluído com sucesso!");
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
