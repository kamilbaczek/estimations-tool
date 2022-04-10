﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Shared.Infrastructure")]
namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.Telemetry;

using Microsoft.Extensions.DependencyInjection;

internal static class AzureApplicationInsightsModule
{
    internal static IServiceCollection AzureApplicationInsights(this IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetry();

        return services;
    }
}
