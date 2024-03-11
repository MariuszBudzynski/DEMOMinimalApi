using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Data.Operations
{
    public class DeleteDataUseCase : IDeleteDataUseCase<Post>
    {
        private readonly IRepository<Post> _repository;

        public DeleteDataUseCase(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<Post> ExecuteAsync(int id)
        {
            return await _repository.DeleteData(id);
        }
    }

}
