namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface ISavePostsUseCase<T> where T : class
    {
        Task ExecuteAsync(List<T> posts);
    }
}