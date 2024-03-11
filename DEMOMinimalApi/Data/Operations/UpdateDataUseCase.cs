using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Data.Operations
{
    public class UpdateDataUseCase : IUpdateDataUseCase<Post>
    {
        private readonly IRepository<Post> _repository;

        public UpdateDataUseCase(IRepository<Post> repository)
        {
            _repository = repository;
        }
        public async Task<Post> ExecuteAsync(Post post, int id)
        {
            return await _repository.UpdateData(post, id);
        }
    }
}
