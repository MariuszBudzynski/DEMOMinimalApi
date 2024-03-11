using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Data.Operations
{
    public class GetByIdUseCase : IGetByIdUseCase<Post>
    {
        private readonly IRepository<Post> _repository;

        public GetByIdUseCase(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<Post> ExecuteAsync(int id)
        {
            return await _repository.GetDataById(id);
        }
    }
}
