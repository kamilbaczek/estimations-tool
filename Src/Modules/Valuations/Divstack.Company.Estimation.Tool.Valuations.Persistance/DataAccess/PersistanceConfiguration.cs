using Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Configurations;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess
{
    internal static class PersistanceConfiguration
    {
        internal static void Configure()
        {
            ValuationPersistanceConfiguration.Configure();
        }
    }
}