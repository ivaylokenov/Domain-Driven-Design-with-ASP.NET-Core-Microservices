namespace CarRentalSystem.Application.Statistics.Handlers
{
    using System.Threading.Tasks;
    using Common;
    using Domain.Dealerships.Events.Dealers;

    public class CarAdAddedEventHandler : IEventHandler<CarAdAddedEvent>
    {
        private readonly IStatisticsRepository statistics;

        public CarAdAddedEventHandler(IStatisticsRepository statistics) 
            => this.statistics = statistics;

        public Task Handle(CarAdAddedEvent domainEvent)
            => this.statistics.IncrementCarAds();
    }
}
