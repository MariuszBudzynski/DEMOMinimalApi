using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Data.Operations
{
    public class AddDataUseCase : IAddDataUseCase<Post>
    {
        private readonly IRepository<Post> _repository;

        public AddDataUseCase(IRepository<Post> repository)
        {
            _repository = repository;
        }
        public async Task<Post> ExecuteAsync(Post post)
        {
            return await _repository.AddData(post);
        }
    }
}
