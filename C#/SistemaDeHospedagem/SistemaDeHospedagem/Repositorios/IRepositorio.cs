namespace SistemaDeHospedagem.Repositorios
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> ObterTodos();
        T ObterPorId(int id);
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(int id);
    }
}
