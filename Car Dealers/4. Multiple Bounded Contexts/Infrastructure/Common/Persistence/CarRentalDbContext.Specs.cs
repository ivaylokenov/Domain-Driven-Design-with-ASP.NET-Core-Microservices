namespace CarRentalSystem.Infrastructure.Common.Persistence
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Statistics.Handlers;
    using AutoMapper;
    using Dealership;
    using Domain.Dealerships.Events.Dealers;
    using Domain.Dealerships.Models.Dealers;
    using Domain.Statistics.Models;
    using Events;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Statistics;
    using Xunit;

    public class CarRentalDbContextSpecs
    {
        [Fact]
        public async Task RaisedEventsShouldBeHandled()
        {
            // Arrange
            var services = new ServiceCollection()
                .AddDbContext<CarRentalDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IDealershipDbContext>(provider => provider
                    .GetService<CarRentalDbContext>())
                .AddScoped<IStatisticsDbContext>(provider => provider
                    .GetService<CarRentalDbContext>())
                .AddTransient<IEventDispatcher, EventDispatcher>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient<IEventHandler<CarAdAddedEvent>, CarAdAddedEventHandler>()
                .AddRepositories()
                .BuildServiceProvider();

            var dealer = DealerFakes.Data.GetDealer();
            var dbContext = services.GetService<CarRentalDbContext>();

            var statisticsToAdd = new StatisticsData()
                .GetData()
                .First();

            dbContext.Add(statisticsToAdd);
            await dbContext.SaveChangesAsync();

            // Act
            dbContext.Dealers.Add(dealer);
            await dbContext.SaveChangesAsync();

            // Assert
            var statistics = await dbContext.Statistics.SingleAsync();

            statistics.TotalCarAds.Should().Be(10);
        }
    }
}
