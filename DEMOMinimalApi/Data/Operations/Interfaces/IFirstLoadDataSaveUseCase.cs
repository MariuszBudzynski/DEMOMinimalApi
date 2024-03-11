namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface IFirstLoadDataSaveUseCase<T> where T : class
    {
        Task ExecuteAsync(List<T> data);
    }
}