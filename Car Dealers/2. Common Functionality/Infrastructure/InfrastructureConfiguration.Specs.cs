namespace CarRentalSystem.Infrastructure
{
    using System;
    using System.Reflection;
    using Application.Dealerships.CarAds;
    using AutoMapper;
    using Common.Persistence;
    using Dealership;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<CarRentalDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddTransient(_ => A.Fake<IDealershipDbContext>());

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<ICarAdRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
