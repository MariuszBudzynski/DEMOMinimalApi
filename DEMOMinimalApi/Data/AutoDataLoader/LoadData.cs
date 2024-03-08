using DEMOMinimalApi.Data.Operations.Interfaces;
using Newtonsoft.Json;

namespace DEMOMinimalApi.Data.AutoDataLoader
{
    public class LoadData
    {
        private readonly IAutoLoadDataUseCase _data;

        HttpClient client = new HttpClient();

        public LoadData(IAutoLoadDataUseCase data)
        {
            _data = data;
        }
        public async Task LoadDataJSON(string url)
        { 
            string response = await client.GetStringAsync(url);
            List<Post>? posts = JsonConvert.DeserializeObject<List<Post>>(response);
        }
    }
}
