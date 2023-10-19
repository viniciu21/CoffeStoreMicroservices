using Microsoft.AspNetCore.Mvc;
using Products.Infra.CrossCutting.IOC;
using Products.Infra.Data.Types;

namespace Products.Api.Common.Configuration
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, WebApplication app)
        {
             //TODO: ADD CONFIG FOR MEMORY cache

            services.AddControllers(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version:apiVersion}"));


            });

            services.AddApiVersioning(
                 options =>
                 {
                     options.DefaultApiVersion = new ApiVersion(1,0);
                     options.ReportApiVersions = true;
                     options.AssumeDefaultVersionWhenUnspecified = true;
                     options.UseApiBehavior = false;
                     //TODO: ADD NO Exception handler
                    // options.ErrorResponses = new ApiVersionExceptionHandler();
                 });

            services.AddConfiguration(app);

            services.AddServicesInjection();

            return services;
        }

        public static IServiceCollection AddConfiguration(this IServiceCollection services, WebApplication app)
        {
            services.Configure<ConnectionStringsType>(
                    app.Configuration.GetSection(ConnectionStringsType.KEY)
                );

            return services;
        }
    }
}