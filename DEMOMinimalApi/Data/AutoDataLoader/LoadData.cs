using DEMOMinimalApi.Data.Operations.Interfaces;
using Newtonsoft.Json;

namespace DEMOMinimalApi.Data.AutoDataLoader
{
    public class LoadData
    {
        private readonly IFirstLoadDataSaveUseCase<Post> _savePostsUseCase;
        private readonly string url = "https://jsonplaceholder.typicode.com/posts";

        HttpClient client = new HttpClient();

        public LoadData(IFirstLoadDataSaveUseCase<Post> savePostsUseCase)
        {
            _savePostsUseCase = savePostsUseCase;
        }
        public async Task LoadDataJSON()
        { 
            string response = await client.GetStringAsync(url);
            List<Post>? posts = JsonConvert.DeserializeObject<List<Post>>(response);
            
            await SavePostsToTheDatabase(posts);
        }

        public async Task SavePostsToTheDatabase(List<Post> data)
        {
            await _savePostsUseCase.ExecuteAsync(data);
        }
    }
}
