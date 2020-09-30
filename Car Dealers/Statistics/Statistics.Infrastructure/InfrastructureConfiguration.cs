namespace CarRentalSystem.Infrastructure.Statistics
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddStatisticsInfrastructure(this IServiceCollection services)
            => services
                .AddScoped<IStatisticsDbContext>(provider => provider.GetService<StatisticsDbContext>());
    }
}
