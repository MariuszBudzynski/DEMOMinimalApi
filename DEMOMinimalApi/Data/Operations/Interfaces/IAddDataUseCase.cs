namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface IAddDataUseCase<T> where T : class
    {
        Task<T> ExecuteAsync(T post);
    }
}