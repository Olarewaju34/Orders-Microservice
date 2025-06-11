using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Order.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayerDI(this IServiceCollection services,IConfiguration config)
        {
            // Register your data access layer services here
            string connectionStringTemplate = config.GetConnectionString("MongoDB")!;
            string connectionString = connectionStringTemplate.Replace("$MONGO_HOST", Environment.GetEnvironmentVariable("MONGODB_HOST")).Replace("$MONGO_PORT", Environment.GetEnvironmentVariable("MONGODB_PORT"));
            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
            services.AddScoped<IMongoDatabase>(provider =>
            {
                var client = provider.GetRequiredService<IMongoClient>();

                return client.GetDatabase(Environment.GetEnvironmentVariable("MONGODB_DATABASE"));
            });
         services.AddScoped<IOrdersRepository, OrderRepository>();
            return services;
        }   
    }
}
