namespace DEMOMinimalApi.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task FirstLoadDataSave(List<T> data);
        Task<List<T>> GetAllData();
        Task<T> GetDataById(int id);
        Task<T> DeleteData(int id);
        Task<T> AddData(T data);
        Task<T> UpdateData(T data, int id);
    }
}