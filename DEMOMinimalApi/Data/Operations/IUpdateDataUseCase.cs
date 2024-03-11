
namespace DEMOMinimalApi.Data.Operations
{
    public interface IUpdateDataUseCase<T> where T : class
    {
        Task<T> ExecuteAsync(T data, int id);
    }
}