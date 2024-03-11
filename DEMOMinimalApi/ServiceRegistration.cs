using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Data.Operations;
using DEMOMinimalApi.Data.AutoDataLoader;
using DEMOMinimalApi.Repository.Interfaces;
using DEMOMinimalApi.Repository;

namespace DEMOMinimalApi
{
    public static class ServiceRegistration
    {
        //extending IServiceCollection to remove swelling code
        public static void AddPostServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Post>, PostRepository>();
            services.AddScoped<LoadData>();
            services.AddScoped<IFirstLoadDataSaveUseCase<Post>, FirstLoadDataSaveUseCase>();
            services.AddScoped<IGetAllUseCase<Post>, GetAllUseCase>();
            services.AddScoped<IGetByIdUseCase<Post>, GetByIdUseCase>();
            services.AddScoped<IDeleteDataUseCase<Post>, DeleteDataUseCase>();
            services.AddScoped<IAddDataUseCase<Post>, AddDataUseCase>();
            services.AddScoped<IUpdateDataUseCase<Post>, UpdateDataUseCase>();
        }
    }
}
