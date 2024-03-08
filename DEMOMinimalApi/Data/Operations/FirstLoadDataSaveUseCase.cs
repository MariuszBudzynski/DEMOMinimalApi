using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Data.Operations
{
    public class FirstLoadDataSaveUseCase : FirstLoadDataSaveUseCase<Post>
    {
        private readonly IRepository<Post> _repository;

        public FirstLoadDataSaveUseCase(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(List<Post> posts)
        {
            await _repository.FirstLoadDataSave(posts);
        }
    }
}
