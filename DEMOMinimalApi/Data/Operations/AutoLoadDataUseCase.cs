using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Data.Operations
{
    public class AutoLoadDataUseCase : IAutoLoadDataUseCase
    {
        private readonly IPostRepository _repository;

        public AutoLoadDataUseCase(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync<T>(List<T> posts) where T : class
        {
            await _repository.SavaData(posts);
        }
    }
}
