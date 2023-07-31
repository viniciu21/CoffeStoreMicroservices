using ProductsApi.Common.Middlewares;
using Prometheus;

namespace ProductsApi.Core.Common.IOC
{
    public static class RegistryWebAppServicesExtentions
    {
        public static WebApplication AddHttpConfiguration(this WebApplication app)
        {
            // app.UseHttpsRedirection();

            app.UseMetricServer();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseMiddleware<ResponseMetricMiddleware>();

            app.MapControllers();


            return app;
        }
    }
}