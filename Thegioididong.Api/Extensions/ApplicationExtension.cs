using Thegioididong.Api.Middlewares;

namespace Thegioididong.Api.Extensions
{
    public static class ApplicationExtension
    {
        public static void UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("Thegioididong");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Thegioididong");
                c.DisplayRequestDuration();
            });
            app.UseAuthentication();
            app.UseRouting();
            // app.UseHttpsRedirection(); //for production only
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                //{
                //    Predicate = _ => true,
                //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});
                endpoints.MapDefaultControllerRoute();
            });

            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
