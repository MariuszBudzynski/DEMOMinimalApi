namespace DEMOMinimalApi.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task SavaData(List<T> data);
    }
}