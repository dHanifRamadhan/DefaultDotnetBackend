using DefaultDotnetBackend.Repositories;
using DefaultDotnetBackend.Services;

namespace DefaultDotnetBackend.Configurations
{
    public static class Injector
    {
        public static void RepoInjector(this IServiceCollection services)
        {
            // TODO: Add your own Repository
            services.AddScoped<IBuilderRepository, BuilderRepository>();
            services.AddHttpClient();
        }
        public static void ServiInjector(this IServiceCollection services)
        {
            // TODO: Add your own Service
            services.AddScoped<IBuilderService, BuilderService>();
        }
    }
}