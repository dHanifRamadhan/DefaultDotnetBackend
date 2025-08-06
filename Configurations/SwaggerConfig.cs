using DefaultDotnetBackend;
using DefaultDotnetBackend.Helpers;
using Microsoft.OpenApi.Models;

namespace DefaultDotnetBackend.Configurations {
    public static class SwaggerConfig {
        public static void AddConfigureSwagger(this IServiceCollection services) {
            services.AddSwaggerGen(config => {
                config.SwaggerDoc("base", new OpenApiInfo {
                    Version = "base",
                    Title = "Default Dotnet Backend",
                    Description = "Using for Base Dotnet Backend",
                    Contact = new OpenApiContact {
                        Name = "Email",
                        Email = "d.haniframadhan@gmail.com"
                    }
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });

                config.OperationFilter<HeaderFilter>();
            });
        }
    }
}