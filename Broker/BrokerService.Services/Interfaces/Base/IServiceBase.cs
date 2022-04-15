
namespace BrokerService.Services.Interfaces.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<T> Gravar(T dados);
        Task<List<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
    }
}
