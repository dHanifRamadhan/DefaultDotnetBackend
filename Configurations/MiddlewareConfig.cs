using DefaultDotnetBackend.Middlewares;

namespace DefaultDotnetBackend.Configurations {
    public static class MiddlewareConfig {
        public static void AddConfigureMiddleware(this WebApplication app) {
            app.UseMiddleware<JWTMiddleware>();
        }
    }
}