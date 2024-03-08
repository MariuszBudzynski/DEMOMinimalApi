namespace DEMOMinimalApi.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task SavaData<T>(List<T> posts) where T : class;
    }
}