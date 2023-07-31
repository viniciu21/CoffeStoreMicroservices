using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductsApi.Core.Common.Data;
using ProductsApi.Core.Models.Types;
using ProductsApi.MetricsLogs;

namespace ProductsApi.Core.Common.IOC
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfigurationOptions(configuration);
            services.AddMvc();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddDbContext<ProductsDbContext>(opt => opt.UseNpgsql());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<MetricCollector>();

            services.Configure<ConnectionStringsType>(configuration.GetSection(ConnectionStringsType.KEY));

            return services;
        }

        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddSwagger(IServiceCollection services)
        {
            return services;
        }
    }
}
