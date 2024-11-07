using SistemaDeHospedagem.Models.Entidades;

namespace SistemaDeHospedagem.Repositorios
{
    public class RepositorioQuarto : IRepositorio<Quarto>
    {
        private readonly List<Quarto> _quartos = new List<Quarto>();

        public IEnumerable<Quarto> ObterTodos()
        {
            return _quartos;
        }

        public Quarto ObterPorId(int id)
        {
            return _quartos.FirstOrDefault(q => q.Id == id);
        }

        public void Adicionar(Quarto quarto)
        {
            quarto.Id = _quartos.Count + 1;
            _quartos.Add(quarto);
        }

        public void Atualizar(Quarto quarto)
        {
            var quartoExistente = ObterPorId(quarto.Id);
            if (quartoExistente != null)
            {
                quartoExistente.Numero = quarto.Numero;
                quartoExistente.Tipo = quarto.Tipo;
                quartoExistente.Descricao = quarto.Descricao;
                quartoExistente.Capacidade = quarto.Capacidade;
                quartoExistente.PrecoPorNoite = quarto.PrecoPorNoite;
            }
        }

        public void Excluir(int id)
        {
            var quarto = ObterPorId(id);
            if (quarto != null)
            {
                _quartos.Remove(quarto);
            }
        }
    }
}
