namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface FirstLoadDataSaveUseCase<T> where T : class
    {
        Task ExecuteAsync(List<T> data);
    }
}