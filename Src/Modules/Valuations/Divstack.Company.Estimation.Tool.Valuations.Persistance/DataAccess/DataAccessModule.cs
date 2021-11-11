﻿using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess
{
    internal static class DataAccessModule
    {
        internal static IServiceCollection AddDataAccess(this IServiceCollection services,
            string connectionString)
        {
            services.AddMongo(connectionString);
            services.AddScoped<IValuationsContext, ValuationsContext>();
            services.AddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

            return services;
        }

        private static void AddMongo(this IServiceCollection services, string connectionString)
        {
            // var settings = MongoClientSettings.FromConnectionString(connectionString);
            // var mongoClient = new MongoClient(settings);
            //
            // services.AddSingleton(mongoClient);
        }

        internal static void UseDataAccess(this IApplicationBuilder app)
        {
            PersistanceConfiguration.Configure();
        }
    }
}