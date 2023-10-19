using Products.Api.Core.Common.IOC;
using Products.Infra.CrossCutting.IOC;
using Products.Infra.Data.Types;

namespace Products.Api
{
    public class Program
    {
        // TODO: VALIDAR PROD vs DEV 
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddIoCConfiguration();

            WebApplication app = builder.Build();

            builder.Services.Configure<ConnectionStringsType>(app.Configuration.GetSection(ConnectionStringsType.KEY));
            
            app.AddApplicationConfiguration(builder.Services);

            await app.RunAsync();
        }
    }
}