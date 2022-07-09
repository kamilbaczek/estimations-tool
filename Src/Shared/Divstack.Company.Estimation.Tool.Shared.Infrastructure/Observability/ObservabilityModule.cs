﻿namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Azure.Telemetry;

internal static class ObservabilityModule
{
    internal static IServiceCollection AddObservability(this IServiceCollection services)
    {
        AzureApplicationInsightsModule.AzureApplicationInsights();

        return services;
    }
}
