using ProductsApi.Core.Common.IOC;

namespace ProductsApi
{
    public class Program
    {
        // TODO: VALIDAR PROD vs DEV 
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddServices(builder.Configuration);

            var app = builder.Build();

            app.AddHttpConfiguration();

            await app.RunAsync();
        }
    }
}