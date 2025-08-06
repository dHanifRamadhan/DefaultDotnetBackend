using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DefaultDotnetBackend.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DefaultDotnetBackend.Middlewares {
    public class JWTMiddleware {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly ILogger<JWTMiddleware> _logger;

        public JWTMiddleware(
            RequestDelegate next,
            ILogger<JWTMiddleware> logger,
            IOptions<AppSettings> appSettings
        ) {
            _next = next;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext httpContext /*, IUserService userService*/) {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachUserToContext(httpContext, token/*, userService*/);

            await _next(httpContext);
        }

        public async Task AttachUserToContext(HttpContext httpContext, string token /*, IUserService userService */) {
            try {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);

                tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validateToken);

                var jwtToken = (JwtSecurityToken)validateToken;
                var userCode = jwtToken.Claims.First(x => x.Type == "id").Value;
                
                // httpContext.Items["User"] = await userService.GetByCode(userCode);
            } catch {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsync("Unauthorized");
                _logger.LogError("Unauthorized");
            }
        }
    }
}