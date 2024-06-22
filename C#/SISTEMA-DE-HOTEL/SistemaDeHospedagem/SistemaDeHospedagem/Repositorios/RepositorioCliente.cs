using SistemaDeHospedagem.Models.Entidades;

namespace SistemaDeHospedagem.Repositorios
{
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        private readonly List<Cliente> _cliente = new List<Cliente>();
        public IEnumerable<Cliente> ObterTodos()
        {
            return _cliente;
        }

        public Cliente ObterPorId(int id)
        {
            return _cliente.FirstOrDefault(h => h.Id == id);
        }

        public void Adicionar(Cliente cliente)
        {
            cliente.Id = _cliente.Count() + 1;
            _cliente.Add(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            var clienteExistente = ObterPorId(cliente.Id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.CPF = cliente.CPF;
                clienteExistente.Email = cliente.Email;
                clienteExistente.Telefone = cliente.Telefone;
            }
        }

        public void Excluir(int id)
        {
            var cliente = ObterPorId(id);
            if (cliente != null)
            {
                _cliente.Remove(cliente);
            }
        }
    }
}
