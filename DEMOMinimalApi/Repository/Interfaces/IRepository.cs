namespace DEMOMinimalApi.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task FirstLoadDataSave(List<T> data);
        Task<List<T>> GetAllData();
    }
}