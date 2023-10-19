using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Formatters;
using Products.Api.Common.Middlewares;
using Products.Infra.Data.Types;
using Prometheus;

namespace Products.Api.Core.Common.IOC
{
    public static class WebAppExtentions
    {
        public static WebApplication RegistryWebAppConfigurations(this WebApplication app)
        {
            IWebHostEnvironment env = app.Environment;

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseExceptionHandlerMiddleware();
            app.UseSwaggerConfiguration();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            return app;
        }
    }
}