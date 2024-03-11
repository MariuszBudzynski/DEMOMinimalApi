namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface IGetAllPostsUseCase<T> where T : class
    {
        Task<List<T>> ExecuteAsync();
    }
}