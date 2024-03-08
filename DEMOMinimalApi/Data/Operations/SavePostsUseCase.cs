using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Data.Operations
{
    public class SavePostsUseCase : ISavePostsUseCase<Post>
    {
        private readonly IRepository<Post> _repository;

        public SavePostsUseCase(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(List<Post> posts)
        {
            await _repository.SavaData(posts);
        }
    }
}
