namespace DefaultDotnetBackend.Configurations
{
    public static class Injector
    {
        public static void RepoInjector(this IServiceCollection services)
        {
            // TODO: Add your own Repository
            services.AddHttpClient();
        }
        public static void ServiInjector(this IServiceCollection services)
        {
            // TODO: Add your own Service
        }
    }
}