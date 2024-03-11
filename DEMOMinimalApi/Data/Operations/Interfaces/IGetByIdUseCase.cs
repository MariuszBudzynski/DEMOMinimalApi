namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface IGetByIdUseCase<T> where T : class
    {
        Task<T> ExecuteAsync(int id);
    }
}