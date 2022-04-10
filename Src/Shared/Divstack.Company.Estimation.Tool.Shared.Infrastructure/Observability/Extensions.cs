﻿namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Azure.Telemetry;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    internal static IServiceCollection AddObservability(this IServiceCollection services)
    {
        services.AzureApplicationInsights();
        services.AddSentry();

        return services;
    }

    internal static void UseObservability(this IApplicationBuilder app)
    {
        app.UseSentryTracing();
    }

    internal static void UseObservability(this IWebHostBuilder hostBuilder)
    {
        hostBuilder.UseSentry();
    }
}
