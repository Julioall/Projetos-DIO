using SistemaDeHospedagem.Models.Entidades;
using SistemaDeHospedagem.Models.Enumeradores;
using SistemaDeHospedagem.Repositorios;
using System;

namespace SistemaDeHospedagem.Servicos
{
    public class ServicoQuarto
    {
        private readonly RepositorioQuarto _repositorioQuarto;

        public ServicoQuarto(RepositorioQuarto repositorioQuarto)
        {
            _repositorioQuarto = repositorioQuarto ?? throw new ArgumentNullException(nameof(repositorioQuarto));
        }

        public void ListarQuartos()
        {
            Console.Clear();
            Console.WriteLine("### Listagem de Quartos ###");
            var quartos = _repositorioQuarto.ObterTodos();
            foreach (var quarto in quartos)
            {
                Console.WriteLine($"ID: {quarto.Id} | Número: {quarto.Numero} | Tipo: {quarto.Tipo} | Capacidade: {quarto.Capacidade} | Preço por Noite: R${quarto.PrecoPorNoite}");
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void AdicionarQuarto()
        {
            Console.Clear();
            Console.WriteLine("### Adicionar Novo Quarto ###");
            Console.Write("Número do Quarto: ");
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Número inválido. Digite novamente: ");
            }
            Console.Write("Tipo do Quarto (Luxo, Standard, Econômico, Suite): ");
            if (!Enum.TryParse(Console.ReadLine(), true, out TipoQuarto tipo))
            {
                Console.WriteLine("Tipo inválido. Digite novamente.");
                return;
            }
            Console.Write("Descrição do Quarto: ");
            string descricao = Console.ReadLine();
            Console.Write("Capacidade do Quarto: ");
            int capacidade;
            while (!int.TryParse(Console.ReadLine(), out capacidade))
            {
                Console.WriteLine("Capacidade inválida. Digite novamente: ");
            }
            Console.Write("Preço por Noite: R$");
            decimal precoPorNoite;
            while (!decimal.TryParse(Console.ReadLine(), out precoPorNoite))
            {
                Console.WriteLine("Valor inválido. Digite novamente: ");
            }

            Quarto novoQuarto = new Quarto
            {
                Numero = numero,
                Tipo = tipo,
                Descricao = descricao,
                Capacidade = capacidade,
                PrecoPorNoite = precoPorNoite
            };

            _repositorioQuarto.Adicionar(novoQuarto);
            Console.WriteLine("Quarto adicionado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void AtualizarQuarto()
        {
            Console.Clear();
            Console.WriteLine("### Atualizar Quarto ###");
            Console.Write("Digite o ID do Quarto que deseja atualizar: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente: ");
            }

            Quarto quarto = _repositorioQuarto.ObterPorId(id);
            if (quarto == null)
            {
                Console.WriteLine("Quarto não encontrado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Quarto encontrado: Número {quarto.Numero}");
            Console.WriteLine("Digite os novos dados:");

            Console.Write("Número do Quarto: ");
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Número inválido. Digite novamente: ");
            }
            Console.Write("Tipo do Quarto (Luxo, Standard, Econômico, Outro): ");
            if (!Enum.TryParse(Console.ReadLine(), true, out TipoQuarto tipo))
            {
                Console.WriteLine("Tipo inválido. Digite novamente.");
                return;
            }
            Console.Write("Descrição do Quarto: ");
            string descricao = Console.ReadLine();
            Console.Write("Capacidade do Quarto: ");
            int capacidade;
            while (!int.TryParse(Console.ReadLine(), out capacidade))
            {
                Console.WriteLine("Capacidade inválida. Digite novamente: ");
            }
            Console.Write("Preço por Noite: R$");
            decimal precoPorNoite;
            while (!decimal.TryParse(Console.ReadLine(), out precoPorNoite))
            {
                Console.WriteLine("Valor inválido. Digite novamente: ");
            }

            quarto.Numero = numero;
            quarto.Tipo = tipo;
            quarto.Descricao = descricao;
            quarto.Capacidade = capacidade;
            quarto.PrecoPorNoite = precoPorNoite;

            _repositorioQuarto.Atualizar(quarto);
            Console.WriteLine("Quarto atualizado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ExcluirQuarto()
        {
            Console.Clear();
            Console.WriteLine("### Excluir Quarto ###");
            Console.Write("Digite o ID do Quarto que deseja excluir: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente: ");
            }

            Quarto quarto = _repositorioQuarto.ObterPorId(id);
            if (quarto == null)
            {
                Console.WriteLine("Quarto não encontrado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Quarto encontrado: Número {quarto.Numero}");
            Console.Write("Tem certeza que deseja excluir este quarto? (S/N): ");
            string confirmacao = Console.ReadLine();
            if (confirmacao.ToUpper() == "S")
            {
                _repositorioQuarto.Excluir(id);
                Console.WriteLine("Quarto excluído com sucesso!");
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
