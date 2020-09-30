namespace CarRentalSystem.Domain
{
    using Common.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Renting.Services;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .AddCommonDomain()
                .AddTransient<IRentingScheduleService, RentingScheduleService>();
    }
}
