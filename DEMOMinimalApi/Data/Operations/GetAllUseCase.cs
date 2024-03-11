using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Data.Operations
{
    public class GetAllUseCase : IGetAllUseCase<Post>
    {
        private readonly IRepository<Post> _repository;

        public GetAllUseCase(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<List<Post>> ExecuteAsync()
        {
            return await _repository.GetAllData();
        }
    }

}
