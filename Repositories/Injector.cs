namespace DefaultDotnetBackend.Repositories {
    public static class Injector {
        public static void RepoInjector(this IServiceCollection services) {
            // TODO: Add your own Repository
            services.AddHttpClient();
        }
    }
}