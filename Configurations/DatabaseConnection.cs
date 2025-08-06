using System.Data.Common;
using DefaultDotnetBackend.Enums;
using DefaultDotnetBackend.Database;
using DefaultDotnetBackend.Helpers;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Polly;

// TODO configuration database
namespace DefaultDotnetBackend.Configurations {
    public static class DatabaseConfig {

        private const DatabaseCollection mainDatabase = DatabaseCollection.Npsql;
        public static void AddDatabaseConnections(this IServiceCollection services, IConfiguration configuration) {
            switch (mainDatabase) {
                case DatabaseCollection.Npsql:
                    RegisterNpgsql(services, configuration);
                    break;
                default:
                    ConsoleHelper.ShowError($"Database {mainDatabase} not supported!");
                    break;
            }

            ConsoleHelper.ShowInformation($"Main Database: {mainDatabase}");
        }
        
        private static void RegisterNpgsql(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("NpsqlConnection");
            if (string.IsNullOrEmpty(connectionString))
                return;

            services.AddDbContext<NpsqlDBContext>(options =>
            {
                options.UseNpgsql(
                    connectionString: connectionString,
                    x =>
                    {
                        x.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorCodesToAdd: null
                        );
                    }
                );
            });
        }

        public static void AddDatabaseHealthChecks(this IServiceCollection services, IConfiguration configuration) {
            var healthChecks = services.AddHealthChecks();

            string? npgsqlConnectionString = configuration.GetConnectionString("NpsqlConnection");
            if (!string.IsNullOrEmpty(npgsqlConnectionString))
                healthChecks.AddNpgSql(
                    connectionString: npgsqlConnectionString,
                    name: "Npsql",
                    tags: new[] { "database", "ready" }
                );
        }

        public async static Task AddTestDatabaseConnection(this IConfiguration configuration) {
            switch (mainDatabase) {
                case DatabaseCollection.Npsql:
                    await TestNpgsqlConnection(configuration);
                    break;
                default:
                    ConsoleHelper.ShowError($"Database {mainDatabase} not supported!");
                    break;
            }
        }

        private async static Task TestNpgsqlConnection(this IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("NpsqlConnection");
            if (string.IsNullOrEmpty(connectionString)) return;

            await using var connection = new NpgsqlConnection(connectionString);
            
            var policy = Policy
            .Handle<NpgsqlException>()
            .Or<TimeoutException>()
            .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: retryCount => TimeSpan.FromSeconds(Math.Pow(2, retryCount)),
                onRetry: (exception, delay, retryCount, context) => {
                    ConsoleHelper.ShowError($"PostgreSQL connection attampt  {retryCount} failed.");
                    ConsoleHelper.ShowInformation($"Waiting {delay} before next retry.");
                    ConsoleHelper.ShowError($"Exception : {exception.Message}");
                }
            );

            await policy.ExecuteAsync(async () => {
                await connection.OpenAsync();
                ConsoleHelper.ShowSuccess("Successfully connected to PostgreSQL database.");
                await connection.CloseAsync();
            });
        }
    }
}