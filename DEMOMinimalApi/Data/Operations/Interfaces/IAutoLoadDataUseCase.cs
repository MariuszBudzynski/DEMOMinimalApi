namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface IAutoLoadDataUseCase
    {
        Task ExecuteAsync<T>(List<T> posts) where T : class;
    }
}