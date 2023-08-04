
namespace TesteBC.Service.Interfaces
{
    public interface ICRUDService<T>
    {
        Task<IEnumerable<T>> BuscaTodos();
        Task Adiciona(T obj);
        Task Atualiza(T obj);
        Task Remove(T obj);
    }
}
