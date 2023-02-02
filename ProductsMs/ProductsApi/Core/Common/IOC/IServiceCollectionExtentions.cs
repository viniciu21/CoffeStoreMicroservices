using Microsoft.EntityFrameworkCore;
using ProductsApi.Core.Common.Data;

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
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql("Host=localhost;Database=coffestore;Username=postgres;Password=mysecretpassword"));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
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
