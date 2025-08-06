using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DefaultDotnetBackend.Helpers {
    public class HeaderFilter : IOperationFilter {
        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var Scheme = new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            operation.Security.Add(new OpenApiSecurityRequirement {
                [Scheme] = new List<string>()
            });
        }
    }
}