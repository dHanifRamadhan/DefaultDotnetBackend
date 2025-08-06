namespace DefaultDotnetBackend.Configurations {
    public static class WebApp {
        // TODO: Add your own WebApp
        public static void AddConfigureApp(this WebApplication app) {

            // Configure the Middleware
            app.AddConfigureMiddleware();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI(config => {
                    config.SwaggerEndpoint("/swagger/base/swagger.json", "Base");
                });
                app.UseDeveloperExceptionPage();
            }
            
            app.MapHealthChecks("/health");

            app.UseCors(config => 
                config.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();
            app.MapControllers();
        }
    }
}