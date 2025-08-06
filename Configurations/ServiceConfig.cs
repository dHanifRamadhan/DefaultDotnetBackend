using System.Text.Json.Serialization;
using DefaultDotnetBackend.Repositories;
using DefaultDotnetBackend.Services;
using DefaultDotnetBackend.Helpers;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace DefaultDotnetBackend.Configurations {
    public static class ServiceConfig {
        // TODO: Add your own All Services
        public static void AddConfigureService(this IServiceCollection services, IConfiguration configuration) {
            services.AddDatabaseHealthChecks(configuration);
            services.AddDatabaseConnections(configuration);

            services.AddControllers().AddJsonOptions(options => {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddEndpointsApiExplorer();
            services.AddConfigureSwagger();
            
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            
            // TODO: Fluent Validation in use Default
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.RepoInjector();
            services.ServiInjector();

            services.AddHttpContextAccessor();
            services.AddResponseCompression();
        }
    }
}