using Microsoft.AspNetCore.Mvc;

namespace DEMOMinimalApi.Data.Operations.Interfaces
{
    public interface IGetAllUseCase<T> where T : class
    {
        Task<List<T>> ExecuteAsync();
    }
}