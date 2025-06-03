using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Order.BusinessLogic.Services;

namespace Order.BusinessLogic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicDI(this IServiceCollection services, IConfiguration configuration)
        {
        // Register your business logic services here
         services.AddScoped<IOrderService, OrderService>();
            string connectionStringTemplate = configuration.GetConnectionString("MongoDB")!;
           string connectionString = connectionStringTemplate.Replace("$MONGO_HOST", Environment.GetEnvironmentVariable("MONGODB_HOST")).Replace("$MONGO_PORT", Environment.GetEnvironmentVariable("MONGODB_PORT"));
            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
            services.AddScoped<IMongoDatabase>(provider =>
            {
                var client = provider.GetRequiredService<IMongoClient>();
              
                return client.GetDatabase("OrderDatabase");
            });

            return services;
        }
    }
}
