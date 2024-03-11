namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface IDeleteDataUseCase<T> where T : class
    {
        Task<T> ExecuteAsync(int id);
    }
}