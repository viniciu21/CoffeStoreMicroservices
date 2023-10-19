using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Infra.Data.Types;

namespace Products.Infra.CrossCutting.IOC
{
    public static class InjectorExtentions
    {
        public static IServiceCollection AddServicesInjection(this IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();

            //services.AddConfigurationOptions(configuration);
            //services.AddMvc();
            //services.AddControllers();
            //services.AddEndpointsApiExplorer();
            //services.AddDbContext<ProductsDbContext>(opt => opt.UseNpgsql());
            //services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            //services.AddSingleton<MetricCollector>();

            //services.Configure<ConnectionStringsType>(configuration.GetSection(ConnectionStringsType.KEY));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection repositories)
        {
            return repositories;
        }
    }
}
